using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EntityCreation : MonoBehaviour
{
    public Button togglePopupButton;
    public Image creationPopupMenu;
    private bool isMenuOpen;

    public UIGamePlayController uiGamePlayController;

    public EnumTypeDropdown unitTypeDropdown;

    public TemplateDropdown allUnitNameTemplateDropdown;
     
    public TemplateDropdown templateDropdown;

    public TMP_InputField nameInputField;



    public GameObject saveButton;
    public GameObject newTemplateButton;

    public Button fabricateUnitButton;
    public Button deleteUnitButton;


    public Sprite normalSaveIcon;
    public Sprite hoverSaveIcon;


    public TemplateType templateType;
    public TemplateManager templateManager;
    public UnitManager unitManager;

    private int currentIndexAllUnit;

    private ButtonController saveButtonController;
    private ButtonController newButtonController;
    private ButtonController deleteButtonController;

    public PopupWarningController popupWarningController;

    public void InitEntityCreation()
    {
        isMenuOpen = false;
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
        togglePopupButton.onClick.AddListener(TogglePopupButton);
        
        if (templateType == TemplateType.Unit)
        {
            nameInputField.interactable = false;
            nameInputField.onValueChanged.AddListener(delegate { DetectTemplateUnsavedDifference(); });
            
            unitTypeDropdown.InitEnumTypeDropdown();
            unitTypeDropdown.dropdown.onValueChanged.AddListener(delegate { DetectTemplateUnsavedDifference(); });

            allUnitNameTemplateDropdown.InitTemplateDropdown();
            allUnitNameTemplateDropdown.dropdown.onValueChanged.AddListener(delegate { DetectTemplateUnsavedDifferenceUnitChange(allUnitNameTemplateDropdown.dropdown); });

            //allUnitNameTemplateDropdown.dropdown.onDropdownClick.AddListener(UpdateEntityCreation);


            saveButtonController = saveButton.GetComponent<ButtonController>();
            saveButtonController.button.onClick.AddListener(SaveTemplate);

            //deleteUnitButton = saveButton.GetComponent<ButtonController>();
            deleteUnitButton.onClick.AddListener(PopupWarningForDelete);

            newButtonController = newTemplateButton.GetComponent<ButtonController>();
            newButtonController.button.onClick.AddListener(SaveCheckForNewTemplate);


            popupWarningController.gameObject.SetActive(false);

        }
        else if (templateType == TemplateType.Building) 
        {
            templateDropdown.InitTemplateDropdown();
        }

        templateManager.InitTemplateManager();
    }


    public void UpdateEntityCreation()
    {
       // DetectTemplateUnsavedDifferenceForIcon();
    }


  

    private void SaveTemplate()
    {
        //Debug.Log("SaveTemplate");

        if (templateType == TemplateType.Unit)
        {
            if (saveButton.GetComponent<ButtonController>().isActive)
            {
                Debug.Log("save Hit");
                templateManager.UpdateTemplate(allUnitNameTemplateDropdown.GetSelectedEntityHandle(), templateType, 10, 2, unitTypeDropdown.SelectedUnitType, nameInputField.text);
                allUnitNameTemplateDropdown.UpdateTemplateDropdown();
                allUnitNameTemplateDropdown.dropdown.RefreshShownValue();
                DetectTemplateUnsavedDifference();
            }
        }
    }

    private void UpdateAllFields(TMP_Dropdown dropdown)
    {

        string selectedOptionText = dropdown.options[dropdown.value].text;
        currentIndexAllUnit = dropdown.value;

        nameInputField.text = selectedOptionText;
        nameInputField.interactable = true;

        //if (dropdown.value != 0)
        //{
        //    string selectedOptionText = dropdown.options[dropdown.value].text;
        
        //    nameInputField.text = selectedOptionText;
        //    nameInputField.interactable = true;

        //}
        //else
        //{
        //    nameInputField.text = string.Empty;
        //    nameInputField.interactable = false;
        //}
    }


    public void TogglePopupButton() 
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen) 
        {
            uiGamePlayController.PopupIsOpening(this);
        }
        
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
    }

    // return bool for isMenuOpen
    public bool GetIsMenuOpen()
    {
        return isMenuOpen;
    }

    public void NewTemplate()
    {
        if (templateType == TemplateType.Unit)
        {

            // 3. create new blank template
            nameInputField.text = string.Empty;
            EntityHandle newTemplateHandle = templateManager.CreateTemplate(TemplateType.Unit, 10, 2, UnitType.Residential, nameInputField.text);
            allUnitNameTemplateDropdown.UpdateTemplateDropdown();
            allUnitNameTemplateDropdown.dropdown.RefreshShownValue();
            saveButtonController.IsActive = true;
            //nameInputField.text = "New Unit Name";
            nameInputField.placeholder.gameObject.SetActive(true);

            // Get the actual template using the handle
            //Template newTemplate = (Template)EntityManager.Instance.GetEntity(newTemplateHandle);
            nameInputField.interactable = true;
   
        }
    }

    public void ClearTemplate()
    {

    }


    private void SaveCheckForNewTemplate()
    {

        if (allUnitNameTemplateDropdown.GetSelectedEntityHandle() == null)
        {
            NewTemplate();
            return;
        }
        Template currentSavedTemplate = templateManager.GetTemplate(allUnitNameTemplateDropdown.GetSelectedEntityHandle());
        

        
        if (nameInputField.text == string.Empty && nameInputField.interactable)
        {   // 1. Check if the name is empty
            Debug.Log("Check if the name is empty");
            popupWarningController.gameObject.SetActive(true);
            popupWarningController.referenceToEntityCreation(this);
            popupWarningController.InitPopupWarning(WarningTypes.blankTemplateName);
        }
        else if (unitTypeDropdown.SelectedUnitType != currentSavedTemplate.UnitType
              || nameInputField.text != currentSavedTemplate.Name)
        {   // 2. check if any changes have not been saved
            Debug.Log("check if any changes have not been saved");

            popupWarningController.gameObject.SetActive(true);
            popupWarningController.referenceToEntityCreation(this);
            popupWarningController.InitPopupWarning(WarningTypes.save);
        }
        else
        {
            NewTemplate();
        }
    }

    private void FabricateUnit(Template template)
    {
       
        if (templateType == TemplateType.Unit)
        {

            EntityHandle newFabricatedUnitHandle = unitManager.CreateUnit(template);

            // Get the actual unit using the handle
            //unit newFabricatedUnit = (FabricatedUnit)EntityManager.Instance.GetEntity(newFabricatedUnitHandle);

        }


    }

    private void DetectTemplateUnsavedDifferenceUnitChange(TMP_Dropdown dropdown)
    {
        bool isDifferent = false;

        Template currentSavedTemplate = templateManager.GetTemplate(allUnitNameTemplateDropdown.GetSelectedEntityHandle());

        if (nameInputField.text != currentSavedTemplate.Name)
        {
            Debug.Log("nameInputField.text == currentSavedTemplate.Name");
            isDifferent = true;
        }

        if (unitTypeDropdown.SelectedUnitType != currentSavedTemplate.UnitType)
        {
            Debug.Log("unitTypeDropdown");
            isDifferent = true;
        }

        if (isDifferent)
        {
            //Debug.Log("isDifferent");
            saveButtonController.IsActive = true;
        }
        else
        {
            //Debug.Log("!isDifferent");
            saveButtonController.IsActive = false;
        }
    }


    private void DetectTemplateUnsavedDifference()
    {
        if (allUnitNameTemplateDropdown.GetSelectedEntityHandle() != null)
        {
            bool isDifferent = false;

            Template currentSavedTemplate = templateManager.GetTemplate(allUnitNameTemplateDropdown.GetSelectedEntityHandle());
            //Debug.Log(allUnitNameTemplateDropdown.dropdown.value);
            //if(allUnitNameTemplateDropdown.dropdown.value != 0)
            //{
            //    
            //}
            //else
            //{
            //    //popupWarningController.gameObject.SetActive(true);
            //    //popupWarningController.referenceToEntityCreation(this);
            //    //popupWarningController.InitPopupWarning(WarningTypes.save);
            //   // return;
            //}


            // continue
            if (nameInputField.text != currentSavedTemplate.Name)
            {
                Debug.Log("nameInputField.text == currentSavedTemplate.Name");
                isDifferent = true;
            }

            if (unitTypeDropdown.SelectedUnitType != currentSavedTemplate.UnitType)
            {
                Debug.Log("unitTypeDropdown");
                isDifferent = true;
            }

            //if (nameInputField.text == string.Empty && allUnitNameTemplateDropdown.dropdown.value != 0)
            //{
            //    //popupWarningController.gameObject.SetActive(true);
            //    //popupWarningController.referenceToEntityCreation(this);
            //    //popupWarningController.InitPopupWarning(WarningTypes.blankTemplateName);
            //    //isDifferent = true;
            //}


            if (isDifferent)
            {
                //Debug.Log("isDifferent");
                saveButtonController.IsActive = true;
            }
            else
            {
                //Debug.Log("!isDifferent");
                saveButtonController.IsActive = false;
            }

        }




    }


    private bool DetectTemplateUnsavedDifferenceForNew()
    {
        return false;

    }

    private void PopupWarningForDelete()
    {
        popupWarningController.gameObject.SetActive(true);
        popupWarningController.referenceToEntityCreation(this);
        popupWarningController.InitPopupWarning(WarningTypes.DeleteTemplate);
    }

    public void DeleteCurrentTemplate()
    {
        if (allUnitNameTemplateDropdown.GetSelectedEntityHandle() != null)
        {
            Template currentSavedTemplate = templateManager.GetTemplate(allUnitNameTemplateDropdown.GetSelectedEntityHandle());
            templateManager.DeleteTemplate(currentSavedTemplate.handle);
            allUnitNameTemplateDropdown.UpdateTemplateDropdown();
            allUnitNameTemplateDropdown.dropdown.RefreshShownValue();
            nameInputField.text = string.Empty;
            nameInputField.interactable = false;
            saveButtonController.IsActive = false;
        }
    }

}
