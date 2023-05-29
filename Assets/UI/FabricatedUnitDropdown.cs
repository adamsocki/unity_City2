using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FabricatedUnitDropdown : MonoBehaviour
{


    public TMP_Dropdown dropdown;
    public UnitManager unitManager;
    private List<EntityHandle> _fabricatedUnitHandles = new List<EntityHandle>();
    public GameData gameData;
    public EntityManager entityManager;

    public void InitFabricatedUnitDropdown()
    {
        if (gameData.FabricatedUnitHandles != null && dropdown != null)
        {
            //Debug.Log("fabUnitinit");
            UpdateFabricatedUnitsDropdown();
        }
    }

    private void OnEnable()
    {
        if (gameData.FabricatedUnitHandles != null && dropdown != null)
        {
            UpdateFabricatedUnitsDropdown();
        }
    }


    private void UpdateFabricatedUnitsDropdown()
    {

        _fabricatedUnitHandles = gameData.FabricatedUnitHandles;
        dropdown.options.Clear();

        if (_fabricatedUnitHandles != null)
        {
            foreach (var fabricatedUnitHandle in _fabricatedUnitHandles)
            {
                FabricatedUnit fabricatedUnit = (FabricatedUnit)entityManager.GetEntity(fabricatedUnitHandle);
                
                EntityOptionData newOption = new EntityOptionData(fabricatedUnit.Name.ToString(), fabricatedUnitHandle);
                dropdown.options.Add(newOption);
                int newIndex = dropdown.options.Count - 1;
                dropdown.value = newIndex;
                // dropdown.options.Add(new TMP_Dropdown.OptionData(template.Name.ToString()));

                break;

                //switch (fabricatedUnit.TemplateType)
                //{
                //    case TemplateType.Unit:
                //        {
                //            EntityOptionData newOption = new EntityOptionData(template.Name.ToString(), templateHandle);
                //            dropdown.options.Add(newOption);
                //            int newIndex = dropdown.options.Count - 1;
                //            ChangeSelectedIndex(newIndex);
                //            // dropdown.options.Add(new TMP_Dropdown.OptionData(template.Name.ToString()));

                //            break;
                //        }
                //    default:
                //        {
                //            break;
                //        }
                //}
                // Template template = (Template)entityManager.GetEntity(templateHandle);
                //dropdown.options.Add(new TMP_Dropdown.OptionData(template.Size.ToString()));
            }
        }



    }

}
