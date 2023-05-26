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



    public Button fabricateTemplateButton;
    public Button saveTemplateButton;

    public Sprite normalSaveIcon;
    public Sprite hoverSaveIcon;


    public TemplateType templateType;
    public TemplateManager templateManager;



    public void InitEntityCreation()
    {
        isMenuOpen = false;
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
        togglePopupButton.onClick.AddListener(TogglePopupButton);
        fabricateTemplateButton.onClick.AddListener(FabricateTemplate);


        if (templateType == TemplateType.Unit)
        {
            saveTemplateButton.onClick.AddListener(SaveTemplate);
            EventTrigger trigger = saveTemplateButton.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry();
            pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
            pointerEnterEntry.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
            trigger.triggers.Add(pointerEnterEntry);

            EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry();
            pointerExitEntry.eventID = EventTriggerType.PointerExit;
            pointerExitEntry.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
            trigger.triggers.Add(pointerExitEntry);

            unitTypeDropdown.InitEnumTypeDropdown();
            allUnitNameTemplateDropdown.InitTemplateDropdown();
            allUnitNameTemplateDropdown.dropdown.onValueChanged.AddListener(delegate { UpdateAllFields(allUnitNameTemplateDropdown.dropdown); });

        }
        else if (templateType == TemplateType.Building) 
        {
            templateDropdown.InitTemplateDropdown();
        }


        templateManager.InitTemplateManager();
    }

    private void OnPointerEnter(PointerEventData data)
    {
        saveTemplateButton.GetComponent<Image>().sprite = hoverSaveIcon;
    }

    private void OnPointerExit(PointerEventData data)
    {
        saveTemplateButton.GetComponent<Image>().sprite = normalSaveIcon;
    }


    private void SaveTemplate()
    {
        Debug.Log("save");
        templateManager.UpdateTemplate(allUnitNameTemplateDropdown.GetSelectedEntityHandle(), TemplateType.Unit, 10, 2, UnitType.Residential, nameInputField.text);
        allUnitNameTemplateDropdown.UpdateTemplateDropdown();
        allUnitNameTemplateDropdown.dropdown.RefreshShownValue();
    }

    private void UpdateAllFields(TMP_Dropdown dropdown)
    {
        string selectedOptionText = dropdown.options[dropdown.value].text;
        nameInputField.text = selectedOptionText;
    }


    public void TogglePopupButton() 
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen) 
        {
            Debug.Log("ShouldN");
            uiGamePlayController.PopupIsOpening(this);
        }
        
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
    }

    // return bool for isMenuOpen
    public bool GetIsMenuOpen()
    {
        return isMenuOpen;
    }

    
    private void FabricateTemplate()
    {

        if (templateType == TemplateType.Unit) 
        {
            EntityHandle newTemplateHandle = templateManager.CreateTemplate(TemplateType.Unit, 10, 2, UnitType.Residential, nameInputField.text );
            allUnitNameTemplateDropdown.UpdateTemplateDropdown();
            allUnitNameTemplateDropdown.dropdown.RefreshShownValue();
            // Get the actual template using the handle
            //Template newTemplate = (Template)EntityManager.Instance.GetEntity(newTemplateHandle);

        }


    }





}
