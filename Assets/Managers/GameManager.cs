using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public ExecutionManager executionManager;

    // Start is called before the first frame update
    void Start()
    {
        executionManager.InitExecutionManager();
    }

    // Update is called once per frame
    void Update()
    {
        executionManager.UpdateExecutionManager();

    }
}
