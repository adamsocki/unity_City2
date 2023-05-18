using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<Template> Templates { get; private set; }

    private void Start()
    {
        Templates = new List<Template>();
    }

    public void AddTemplate(Template template)
    {
        Templates.Add(template);
    }
    // ... any other methods you want for manipulating Templates
}
