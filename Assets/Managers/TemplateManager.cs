using System.Collections.Generic;
using UnityEngine;

public enum TemplateType
{
    Unit,
    Building
}

public class Template
{
    public TemplateType TemplateType { get; set; }
    public int Size { get; set; }
    public int NumberOfRooms { get; set; }
    public string UnitType { get; set; }
}

public class TemplateManager : MonoBehaviour
{
    List<Template> templates;

    public void InitTemplateManager()
    {
        templates = new List<Template>();
    }

    public void CreateTemplate(TemplateType templateType, int size, int numberOfRooms, string unitType)
    {
        Template newTemplate = new Template()
        {
            TemplateType = templateType,
            Size = size,
            NumberOfRooms = numberOfRooms,
            UnitType = unitType
        };

        templates.Add(newTemplate);
    }

    public List<Template> GetTemplatesByType(TemplateType type)
    {
        // Return a list of templates filtered by the specified type
        return templates.FindAll(t => t.TemplateType == type);
    }

    public List<Template> GetAllTemplates()
    {
        // Return the entire list of templates
        return templates;
    }

    public List<Template> GetTemplatesBySize(int size)
    {
        List<Template> filteredTemplates = new List<Template>();
        foreach (Template template in templates)
        {
            if (template.Size == size)
            {
                filteredTemplates.Add(template);
            }
        }
        return filteredTemplates;
    }

    public List<Template> GetTemplatesByRooms(int rooms)
    {
        List<Template> filteredTemplates = new List<Template>();
        foreach (Template template in templates)
        {
            if (template.NumberOfRooms == rooms)
            {
                filteredTemplates.Add(template);
            }
        }
        return filteredTemplates;
    }

    public List<Template> GetTemplatesByUnitType(string unitType)
    {
        List<Template> filteredTemplates = new List<Template>();
        foreach (Template template in templates)
        {
            if (template.UnitType.Equals(unitType))
            {
                filteredTemplates.Add(template);
            }
        }
        return filteredTemplates;
    }


}
