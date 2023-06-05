using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static ResidentialUnitGenerator;

public class UnitRenderTempalte : MonoBehaviour
{

    public ResidentialUnitGenerator residentialUnitGenerator;
    public Button roomPlus;
    public Button roomMinus;
    public Button roomShuffle;
    public int roomCount;

    public TMP_Text roomNumberDisplay;

    
    public void Start()
    {
        roomPlus.onClick.AddListener(PlusRoom);
        roomMinus.onClick.AddListener(MinusRoom);
        roomShuffle.onClick.AddListener(ShuffleRoom);
        InitUnitRenderTempalte();


    }

    public void Update()
    {
        
    }

    private void ShuffleRoom()
    {
        residentialUnitGenerator.DeleteRender();
        residentialUnitGenerator.StartUnitGenerator(roomCount);
    }

    private void PlusRoom() 
    {
        residentialUnitGenerator.DeleteRender();
        roomCount++;
        residentialUnitGenerator.StartUnitGenerator(roomCount);
        roomNumberDisplay.text = roomCount.ToString();
    }

    private void MinusRoom()
    {
        residentialUnitGenerator.DeleteRender();
        if (roomCount > 0)
        {
            roomCount--;
        }
        residentialUnitGenerator.StartUnitGenerator(roomCount);
        roomNumberDisplay.text = roomCount.ToString();

    }

    public void InitUnitRenderTempalte()
    {

        residentialUnitGenerator.DeleteRender();
        residentialUnitGenerator.StartUnitGenerator(roomCount);

        roomNumberDisplay.text = roomCount.ToString();


    }

}
