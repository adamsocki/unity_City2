using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitData : MonoBehaviour
{
 
    public EntityManager entityManager;

    public List<EntityHandle> gameInitBuildingList = new List<EntityHandle>();

    public void InitGameInitData()
    {

        InitBuildings();


    }



    public void InitBuildings()
    {
        // CREATE ALL INIT BASE GAME BUILDING TYPES AVAILBLE TO BUILD

        for (int i = 0; i < 4; i++)
        {
            PortOfEntry portOfEntry = new PortOfEntry();
            portOfEntry.handle = entityManager.AddEntity(EntityType.Building, portOfEntry);
            gameInitBuildingList.Add(portOfEntry.handle);
        }

        // DESIGN BUILDING

        


    }




    public void LoadBuildingUI()
    {






    }
}
