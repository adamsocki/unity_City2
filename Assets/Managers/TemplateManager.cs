using System.Collections.Generic;
using UnityEngine;



public enum TemplateType
{
    Unit,
    Building
}

public class TemplateManager : MonoBehaviour
{
    //public List<EntityHandle> templateHandles;
    public GameData gameData;

    public void InitTemplateManager()
    {
        //templateHandles = new List<EntityHandle>();
    }

    public EntityHandle CreateTemplate(TemplateType templateType, int size, int numberOfRooms, UnitType unitType)
    {
        Template newTemplate = new Template()
        {
            TemplateType = templateType,
            Size = size,
            NumberOfRooms = numberOfRooms,
            UnitType = unitType
        };

        // templates.Add(newTemplate);
        newTemplate.handle = EntityManager.Instance.AddEntity(EntityType.Template, newTemplate);
        gameData.AddTemplate(newTemplate.handle);
        //templateHandles.Add(newTemplate.handle);

        return newTemplate.handle;
    }

    public Template GetTemplate(EntityHandle handle)
    {
        return (Template)EntityManager.Instance.GetEntity(handle);
    }

    public List<Template> GetAllTemplates()
    {
        List<Template> templates = new List<Template>();
        foreach (EntityHandle handle in gameData.TemplateHandles)
        {
            templates.Add(GetTemplate(handle));
        }
        return templates;
    }



}
