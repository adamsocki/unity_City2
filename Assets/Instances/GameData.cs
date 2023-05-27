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

    public void AddUnit(EntityHandle unit)
    {
        FabricatedUnitHandles.Add(unit);
    }


    // ... any other methods you want for manipulating Templates
}
