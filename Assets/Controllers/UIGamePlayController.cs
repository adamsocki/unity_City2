using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;


public class UIGamePlayController : MonoBehaviour
{

    public Button testEntityCreation;
    public EntityManager entityManager;
    public EntityCreation[] entities;
    public EntityCreation unitEntityCreation;
    public EntityCreation buildingEntityCreation;
    
    public BuildingMaker buildingMaker;

    public void InitUIGamePLayController()
    {
        testEntityCreation.onClick.AddListener(TestEntityCreation);
        foreach (EntityCreation entity in entities)
        {
            entity.InitEntityCreation();
        }



        buildingMaker.InitBuildingMaker();


       // unitEntityCreation.InitEntityCreation();
        //buildingEntityCreation.InitEntityCreation();
    }
    
    public void UpdateUIGamePLayController()
    {
        foreach(EntityCreation entity in entities)
        {
            if (entity.GetIsMenuOpen())
            {
                entity.UpdateEntityCreation();

                //foreach(EntityCreation restOfEntities in entities)
                //{
                //    if (restOfEntities != entity)
                //    {
                //        //restOfEntities.TogglePopupButton();
                //    }
                //}
            }
        }
    }

    public void PopupIsOpening(EntityCreation entityThatisOpening)
    {
        foreach (EntityCreation restOfEntitiesToClose in entities)
        {
            if (restOfEntitiesToClose != entityThatisOpening && restOfEntitiesToClose.GetIsMenuOpen())
            {
                restOfEntitiesToClose.TogglePopupButton();
            }
        }

    }


    private void TestEntityCreation()
    {
        Debug.Log("Test");
        Building newBuilding = new Building
        {
            floors = 5,
            address = "123 Main St",
        };

        // Add the new building to the EntityManager
        EntityHandle handle = entityManager.AddEntity(EntityType.Building, newBuilding);
        Entity entity = entityManager.GetEntity(handle);
        if (entity is Building)
        {
            Building building = (Building)entity;
            // Now you can access the Building-specific properties
            Debug.Log(building.floors);
            Debug.Log(building.address);
        }
        else
        {
            // The entity is not a Building
            Debug.LogError("Entity is not a Building.");
        }
    }
}
