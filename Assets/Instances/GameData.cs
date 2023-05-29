using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<EntityHandle> TemplateHandles { get; private set; }
    public List<EntityHandle> FabricatedUnitHandles { get; private set; }

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
