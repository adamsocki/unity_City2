using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TemplateDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TemplateManager templateManager;
    private List<Template> _templates = new List<Template>();
    public GameData gameData;


    public void InitTemplateDropdown()
    {
        
        if (dropdown != null)
        {

        UpdateTemplateDropdown();
        }
       




    }

    public void DropdownValueChanged(TMP_Dropdown dropdown)
    {
        // Your code here
    }


    private void OnEnable()
    {
        if (gameData.Templates != null) 
        {
            UpdateTemplateDropdown();
        }
    }

    public void UpdateTemplateDropdown()
    {

        _templates = gameData.Templates;
        dropdown.options.Clear();
        foreach (var template in _templates)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(template.Size.ToString()));
        }

        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
    }


}
