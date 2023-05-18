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
    public Button fabricateTemplateButton;

    public TemplateManager templateManager;

    public void InitEntityCreation()
    {
        isMenuOpen = false;
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
        togglePopupButton.onClick.AddListener(TogglePopupButton);
        fabricateButton.onClick.AddListener(FabricateTemplate);
        unitTypeDropdown.InitEnumTypeDropdown();


        tempalateManager.InitTempalteManager();
    }

    private void TogglePopupButton()
    {
        isMenuOpen = !isMenuOpen;
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
    }

    


    private void FabricateTemplate()
    {
        templateManager.createTemplate(unitTypeDropdown.SelectedUnitType);




    }





}
