using System.Collections.Generic;
using UnityEngine;



public enum TemplateType
{
    Unit,
    Building
}

public enum StyleType
{
    Flat
}


public class TemplateManager : MonoBehaviour
{
    //public List<EntityHandle> templateHandles;
    public GameData gameData;
    public EntityManager entityManager;

    public void InitTemplateManager()
    {
        //templateHandles = new List<EntityHandle>();
    }

    public EntityHandle CreateTemplate(TemplateType templateType, int size, int numberOfRooms, UnitType unitType, string name, float sizeOfUnit, float fabCost)
    {
        Template newTemplate = new Template()
        {
            Name = name,
            TemplateType = templateType,
            Size = size,
            NumberOfRooms = numberOfRooms,
            UnitType = unitType,
            SizeOfUnit = sizeOfUnit,
            FabCost = fabCost
        };

        // templates.Add(newTemplate);
        newTemplate.handle = entityManager.AddEntity(EntityType.Template, newTemplate);
        gameData.AddTemplate(newTemplate.handle);
        //templateHandles.Add(newTemplate.handle);

        return newTemplate.handle;
    }

    public Template GetTemplate(EntityHandle handle)
    {
        return (Template)entityManager.GetEntity(handle);
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

    public void UpdateTemplate(EntityHandle handle, TemplateType templateType, int size, int numberOfRooms, UnitType unitType, string name, float sizeOfUnit, float fabCost)
    {
        Template existingTemplate = GetTemplate(handle);

        if (existingTemplate != null)
        {
            
            existingTemplate.Name = name;
            existingTemplate.TemplateType = templateType;
            existingTemplate.Size = size;
            existingTemplate.NumberOfRooms = numberOfRooms;
            existingTemplate.UnitType = unitType;
            existingTemplate.SizeOfUnit = sizeOfUnit;
            existingTemplate.FabCost = fabCost;
            //entityManager.UpdateEntity(handle, existingTemplate);

            //EntityHandle handle = // the handle of the entity you want to update.
            //Template entityToUpdate = (Template)entityManager.GetEntity(handle);

        }
    }


    public bool HasTemplateChanged(EntityHandle handle)
    {
        return false;
    }


    public void DeleteTemplate(EntityHandle handle)
    {
        Template template = GetTemplate(handle);
        entityManager.RemoveEntity(handle);
        //templateHandles.Remove(handle);
        gameData.RemoveTemplate(handle);
    }


}
