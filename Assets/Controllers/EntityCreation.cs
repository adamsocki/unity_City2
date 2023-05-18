using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityCreation : MonoBehaviour
{
    public Button togglePopupButton;
    public Image creationPopupMenu;
    private bool isMenuOpen;

    public UIGamePlayController uiGamePlayController;

    public EnumTypeDropdown unitTypeDropdown;
    public TemplateDropdown templateDropdown;
    public Button fabricateTemplateButton;

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
            unitTypeDropdown.InitEnumTypeDropdown();
        
        }
        else if (templateType == TemplateType.Building)
        {
            templateDropdown.InitTemplateDropdown();
        }


        templateManager.InitTemplateManager();
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

    
    private void FabricateTemplate()
    {

        if (templateType == TemplateType.Unit) 
        {
            EntityHandle newTemplateHandle = templateManager.CreateTemplate(TemplateType.Unit, 10, 2, UnitType.Residential);

            // Get the actual template using the handle
            //Template newTemplate = (Template)EntityManager.Instance.GetEntity(newTemplateHandle);

        }


    }





}
