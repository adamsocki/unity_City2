using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityCreation : MonoBehaviour
{
    public Button togglePopupButton;
    public Image creationPopupMenu;
    private bool isMenuOpen;
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

    private void TogglePopupButton()
    {
        isMenuOpen = !isMenuOpen;
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
        
    }

    
    private void FabricateTemplate()
    {
        if (templateType == TemplateType.Unit) 
        { 
            templateManager.CreateTemplate(templateType, 10, 10, unitTypeDropdown.SelectedUnitType);
            
        }


    }





}
