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
    private List<EntityHandle> _templateHandles = new List<EntityHandle>();
    public GameData gameData;
    public EntityManager entityManager;


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
        if (gameData.TemplateHandles != null) 
        {
            UpdateTemplateDropdown();
        }
    }

    public void UpdateTemplateDropdown()
    {

        _templateHandles = gameData.TemplateHandles;
        dropdown.options.Clear();
        foreach (var templateHandle in _templateHandles)
        {
            Template template = (Template)entityManager.GetEntity(templateHandle);
            dropdown.options.Add(new TMP_Dropdown.OptionData(template.Size.ToString()));
        }

        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
    }
}
