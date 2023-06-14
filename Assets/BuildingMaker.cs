using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingMaker : MonoBehaviour
{


    public GameInitData gameInitData;

    public EntityManager entityManager;

    public Button openBuildingConstructorButton;
    public Image buildingConstructorUI;

    public Button[] buildingConstructorButtons;

    //public 




    public void InitBuildingMaker()
    {
        openBuildingConstructorButton.onClick.AddListener(OpenBuildingConstructor);


        // LOAD INIT GAME DATA
        InitLoadBuildingUI();







        buildingConstructorUI.gameObject.SetActive(false);




    }



    private void InitLoadBuildingUI()
    {
        foreach(EntityHandle initBuilding in gameInitData.gameInitBuildingList)
        {
            // Get Entity from manager
            Entity entity = entityManager.GetEntity(initBuilding);

            switch(initBuilding.type)
            {
                case EntityType.Building:
                    // Get Building from entity
                    Building building = (Building)entity;

                    switch(building.buildingType)
                    {
                        case BuildingType.PortOfEntry:
                            // Get PortOfEntry from building
                            PortOfEntry portOfEntry = (PortOfEntry)building;

                            switch(portOfEntry.type)
                            {
                                case PortOfEntryType.gate:
                                    // Get Gate from portOfEntry
                                    // Gate gate = (Gate)portOfEntry;

                                    // // Get Gate UI from button
                                    // GateUI gateUI = buildingConstructorButtons[0].GetComponent<GateUI>();

                                    // // Set Gate UI values
                                    // gateUI.SetGateUIValues(gate);

                                    break;
                                case PortOfEntryType.airport:
                                    // Get Airport from portOfEntry
                                    // Airport airport = (Airport)portOfEntry;

                                    // // Get Airport UI from button
                                    // AirportUI airportUI = buildingConstructorButtons[1].GetComponent<AirportUI>();

                                    // // Set Airport UI values
                                    // airportUI.SetAirportUIValues(airport);

                                    break;
                                case PortOfEntryType.seaport:
                                    // Get Seaport from portOfEntry
                                    // Seaport seaport = (Seaport)portOfEntry;

                                    // // Get Seaport UI from button
                                    // SeaportUI seaportUI = buildingConstructorButtons[2].GetComponent<SeaportUI>();

                                    // // Set Seaport UI values
                                    // seaportUI.SetSeaportUIValues(seaport);

                                    break;
                                case PortOfEntryType.busTerminal:
                                    // Get BusTerminal from portOfEntry
                                    // BusTerminal busTerminal = (BusTerminal)portOfEntry;

                                    // // Get BusTerminal UI from button
                                    // BusTerminalUI busTerminalUI = buildingConstructorButtons[3].GetComponent<BusTerminalUI>();

                                    // // Set BusTerminal UI values
                                    // busTerminalUI.SetBusTerminalUIValues(busTerminal);

                                    break;
                                default:
                                    break;
                            }

                            break;
                        default:
                            break;
                    }

                    break;
                
              
                default:
                    break;
            }






        }
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
