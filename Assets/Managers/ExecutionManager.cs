using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionManager : MonoBehaviour
{

    public PlayerManager playerManager;
    public UIManager uiManager;
    // Start is called before the first frame update
    public void InitExecutionManager()
    {
        playerManager.InitPlayerManager();
        uiManager.InitUIManager();
    }

    // Update is called once per frame
    public void UpdateExecutionManager()
    {
        playerManager.UpdatePlayerManager();
        uiManager.UpdateUIManager();
    }
   
}
