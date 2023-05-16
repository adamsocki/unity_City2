using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CameraController cameraController;
    //public ObjectPlacerController objectPlacerController;

    public void InitPlayerManager()
    {   // ExecutionManager
        cameraController.InitCameraController();
        //objectPlacerController.InitPlacerController();
    }

    public void UpdatePlayerManager()
    {   // ExecutionManager
        cameraController.UpdateCameraController();
        //objectPlacerController.UpdatePlacerController();
    }
}
