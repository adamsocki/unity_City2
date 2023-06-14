using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionManager : MonoBehaviour
{

    public PlayerManager playerManager;
    public UIManager uiManager;


    public GameInitData gameInitData;



    public BuildingManager buildingManager;
    // Start is called before the first frame update
    public void InitExecutionManager()
    {
        playerManager.InitPlayerManager();
        uiManager.InitUIManager();

        gameInitData.InitGameInitData();

        buildingManager.InitBuildingMananger();
    }

    // Update is called once per frame
    public void UpdateExecutionManager()
    {
        playerManager.UpdatePlayerManager();
        uiManager.UpdateUIManager();

        buildingManager.UpdateBuildingMananger();
    }
   
}
