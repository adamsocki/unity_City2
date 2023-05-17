using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CameraController cameraController;
    public EntityPlacementController entityPlacementController;

    public void InitPlayerManager()
    {   // ExecutionManager
        // cameraController.InitCameraController();
        entityPlacementController.InitEntityPlacementController();
    }

    public void UpdatePlayerManager()
    {   // ExecutionManager
        cameraController.UpdateCameraController();
        entityPlacementController.UpdateEntityPlacementController();
    }
}
