using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;


public enum TemplateDropdownType
{
    name,
    unit
}


public class TemplateDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TemplateManager templateManager;
    private List<EntityHandle> _templateHandles = new List<EntityHandle>();
    public GameData gameData;
    public EntityManager entityManager;
    public TemplateDropdownType templateDropdownType;


    public void InitTemplateDropdown()
    {
        
        if (dropdown != null)
        {
            UpdateTemplateDropdown();
        }
       
        switch(templateDropdownType)
        {
            case TemplateDropdownType.name:
            {

                break;
            }
            case TemplateDropdownType.unit:
            {
                break;
            }
            default:
                break;
        }



    }

    public void DropdownValueChanged(TMP_Dropdown dropdown)
    {
        EntityOptionData selectedOption = dropdown.options[dropdown.value] as EntityOptionData;
        EntityHandle selectedEntityHandle = selectedOption.handle;

        // Now you have the EntityHandle of the selected value in the dropdown
        Debug.Log("Selected entity's ID: " + selectedEntityHandle.idLocationInsideInfo);

    }

    public EntityHandle GetSelectedEntityHandle()
    {
        if (dropdown.value < dropdown.options.Count)
        {
            EntityOptionData selectedOption = dropdown.options[dropdown.value] as EntityOptionData;
            if (selectedOption != null)
            {
                Debug.Log("GetEntitySelected");
                return selectedOption.handle;
            }
        }
        return null;  // Return null if no valid selection
    }


    private void OnEnable()
    {
        if (gameData.TemplateHandles != null && dropdown != null) 
        {
            UpdateTemplateDropdown();
        }
    }

    public void UpdateTemplateDropdown()
    {

        _templateHandles = gameData.TemplateHandles;
        dropdown.options.Clear();

        if (_templateHandles != null)
        {
            foreach (var templateHandle in _templateHandles)
            {
                Template template = (Template)entityManager.GetEntity(templateHandle);
                switch (template.TemplateType)
                {
                    case TemplateType.Unit:
                        {
                            EntityOptionData newOption = new EntityOptionData(template.Name.ToString(), templateHandle);
                            dropdown.options.Add(newOption);

                            // dropdown.options.Add(new TMP_Dropdown.OptionData(template.Name.ToString()));

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                // Template template = (Template)entityManager.GetEntity(templateHandle);
                //dropdown.options.Add(new TMP_Dropdown.OptionData(template.Size.ToString()));
            }
        }
        

        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
    }
}
