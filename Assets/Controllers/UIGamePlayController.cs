using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIGamePlayController : MonoBehaviour
{

    public Button testEntityCreation;
    public EntityManager entityManager;

    public void InitUIGamePLayController()
    {
        testEntityCreation.onClick.AddListener(TestEntityCreation);
    }
    
    public void UpdateUIGamePLayController()
    {
        
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
