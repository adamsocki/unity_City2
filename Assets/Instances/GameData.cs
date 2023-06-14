using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<EntityHandle> TemplateHandles { get; private set; }
    public List<EntityHandle> FabricatedUnitHandles { get; private set; }

    

    public List<EntityHandle> PortOfEntryHandles { get; private set; }



    public void AddEntityToDataList(EntityHandle entityHandle, List<EntityHandle> entityHandleList)
    {
        entityHandleList.Add(entityHandle);
    }

    public void RemoveEntityToDataList(EntityHandle entityHandle, List<EntityHandle> entityHandleList)
    {
        entityHandleList.Remove(entityHandle);
    }


    private void Start()
    {
        TemplateHandles = new List<EntityHandle>();
        FabricatedUnitHandles = new List<EntityHandle>();
    }

    public void AddTemplate(EntityHandle template)
    {
        TemplateHandles.Add(template);
    }

    public void RemoveTemplate(EntityHandle template)
    {
        TemplateHandles.Remove(template);
    }

    public void AddUnit(EntityHandle unit)
    {
        FabricatedUnitHandles.Add(unit);
    }

    public void RemoveUnit(EntityHandle unit)
    {
        FabricatedUnitHandles.Remove(unit);
    }

    // ... any other methods you want for manipulating Templates and Units.

    
}
