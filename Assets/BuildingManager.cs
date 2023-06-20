using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum BuildingType
{
    DesignerBuilding,
    PortOfEntry
}

public class Building : Entity
{
    // Unique properties for buildings...
    public int floors;
    public string address;
    public BuildingType buildingType;
}

public enum PortOfEntryType
{
    designer,
    gate,
    airport,
    seaport,
    busTerminal
}

public class DesignerBuilding : Building
{

}


public class PortOfEntry : Building
{
    public PortOfEntryType type;

}


public class BuildingManager : MonoBehaviour
{
  
    public GameData gameData;
    public DefaultGameData defaultGameData;
    public GameInitData gameInitData;


    public void InitBuildingMananger()
    {



        // LOAD BASE BUILDING TEMPLATES (NON PLAYER DATA)


        




    }

    public void UpdateBuildingMananger()
    {

    }





}
