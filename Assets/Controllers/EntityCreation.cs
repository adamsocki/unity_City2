using System.Collections;
using System.Collections.Generic;
using TMPro;
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


    public Sprite normalSaveIcon;
    public Sprite hoverSaveIcon;


    public TemplateType templateType;
    public TemplateManager templateManager;
    public UnitManager unitManager;


    private ButtonController saveButtonController;
    private ButtonController newButtonController;

    public PopupWarningController popupWarningController;

    public void InitEntityCreation()
    {
        isMenuOpen = false;
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
        togglePopupButton.onClick.AddListener(TogglePopupButton);
        
        if (templateType == TemplateType.Unit)
        {
            //saveTemplateButton.onClick.AddListener(SaveTemplate);
            unitTypeDropdown.InitEnumTypeDropdown();
            allUnitNameTemplateDropdown.InitTemplateDropdown();
            allUnitNameTemplateDropdown.dropdown.onValueChanged.AddListener(delegate { UpdateAllFields(allUnitNameTemplateDropdown.dropdown); });

            saveButtonController = saveButton.GetComponent<ButtonController>();
            saveButtonController.button.onClick.AddListener(SaveTemplate);

            newButtonController = newTemplateButton.GetComponent<ButtonController>();
            newButtonController.button.onClick.AddListener(SaveCheckForNewTemplate);

            nameInputField.interactable = false;

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
        DetectTemplateUnsavedDifferenceForIcon();
    }


  

    private void SaveTemplate()
    {
        //Debug.Log("SaveTemplate");
        if (saveButton.GetComponent<ButtonController>().isActive)
        {
            templateManager.UpdateTemplate(allUnitNameTemplateDropdown.GetSelectedEntityHandle(), TemplateType.Unit, 10, 2, UnitType.Residential, nameInputField.text);
            allUnitNameTemplateDropdown.UpdateTemplateDropdown();
            allUnitNameTemplateDropdown.dropdown.RefreshShownValue();
        }
        
    }

    private void UpdateAllFields(TMP_Dropdown dropdown)
    {
        if (dropdown.value != 0)
        {
            string selectedOptionText = dropdown.options[dropdown.value].text;
        
            nameInputField.text = selectedOptionText;
            nameInputField.interactable = true;

        }
        else
        {
            nameInputField.text = string.Empty;
            nameInputField.interactable = false;
        }
    }


    public void TogglePopupButton() 
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen) 
        {
            //Debug.Log("ShouldN");
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

        if (nameInputField.text == string.Empty && allUnitNameTemplateDropdown.dropdown.value != 0)
        {   // 1. Check if the name is empty
            popupWarningController.gameObject.SetActive(true);
            popupWarningController.referenceToEntityCreation(this);
            popupWarningController.InitPopupWarning(WarningTypes.blankTemplateName);
        }
        else if (DetectTemplateUnsavedDifferenceForNew())
        {   // 2. check if any changes have not been saved

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





    // Detect change state to activate Save Button
    private void DetectTemplateUnsavedDifferenceForIcon()
    {
        bool isDifferent = true;

        if (true)
        {
            isDifferent = false;
        }





        if (isDifferent)
        {
            saveButtonController.IsActive = true;
        }
        else
        {
            saveButtonController.IsActive = false;
        }

       

    }

    private bool DetectTemplateUnsavedDifferenceForNew()
    {
        return false;

    }




}
