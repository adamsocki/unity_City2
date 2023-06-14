using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingMaker : MonoBehaviour
{


    public Button openBuildingConstructorButton;
    public Image buildingConstructorUI;

    public Button[] buildingConstructorButtons;
    



    public void InitBuildingMaker()
    {
        openBuildingConstructorButton.onClick.AddListener(OpenBuildingConstructor);
        buildingConstructorUI.gameObject.SetActive(false);

    }



    private void OpenBuildingConstructor()
    {
        if (buildingConstructorUI.gameObject.activeSelf)
        {
            buildingConstructorUI.gameObject.SetActive(false);
        }
        else
        {
            buildingConstructorUI.gameObject.SetActive(true);
        }
    }

}
