using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitRenderTempalte : MonoBehaviour
{


    public ResidentialUnitGenerator residentialUnitGenerator;
    public Button roomPlus;
    public Button roomMinus;
    private int roomCount;

    public void Start()
    {
        roomPlus.onClick.AddListener(PlusRoom);
        roomMinus.onClick.AddListener(MinusRoom);
    }

    public void Update()
    {
        
    }

    private void PlusRoom()
    {
        residentialUnitGenerator.DeleteRender();
        residentialUnitGenerator.RenderRoom(roomCount);
    }

    private void MinusRoom()
    {
        residentialUnitGenerator.DeleteRender();
        residentialUnitGenerator.RenderRoom(roomCount);

    }


}
