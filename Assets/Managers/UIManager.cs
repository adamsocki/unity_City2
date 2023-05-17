using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   
    public UIGamePlayController uiGamePlayController;

    public void InitUIManager()
    {
        uiGamePlayController.InitUIGamePLayController();
    }

    public void UpdateUIManager()
    {
        uiGamePlayController.UpdateUIGamePLayController();

    }
}
