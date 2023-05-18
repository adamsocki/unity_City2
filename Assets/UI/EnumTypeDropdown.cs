using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class EnumTypeDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public UnitType SelectedUnitType { get; private set; }

    public void InitEnumTypeDropdown()
    {
        dropdown.options = System.Enum.GetNames(typeof(UnitType)).Select(x => new TMP_Dropdown.OptionData(x)).ToList();

        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });

    }

    void DropdownValueChanged(TMP_Dropdown change)
    {
        SelectedUnitType = (UnitType)System.Enum.Parse(typeof(UnitType), change.options[change.value].text);
    }
}