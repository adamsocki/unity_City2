using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<EntityHandle> TemplateHandles { get; private set; }

    private void Start()
    {
        TemplateHandles = new List<EntityHandle>();
    }

    public void AddTemplate(EntityHandle template)
    {
        TemplateHandles.Add(template);
    }
    // ... any other methods you want for manipulating Templates
}
