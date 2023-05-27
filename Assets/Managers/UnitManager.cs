using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameData gameData;
    public EntityManager entityManager;

    public EntityHandle CreateUnit(Template template)
    {
        FabricatedUnit newFabricatedUnit = new FabricatedUnit(template);

        newFabricatedUnit.handle = entityManager.AddEntity(EntityType.Unit, newFabricatedUnit);
        gameData.AddUnit(newFabricatedUnit.handle);

        return newFabricatedUnit.handle;
    }

    public FabricatedUnit GetUnit(EntityHandle handle)
    {
        return (FabricatedUnit)entityManager.GetEntity(handle);
    }

    public List<FabricatedUnit> GetAllUnits()
    {
        List<FabricatedUnit> fabricatedUnits = new List<FabricatedUnit>();
        foreach (EntityHandle handle in gameData.FabricatedUnitHandles)
        {
            fabricatedUnits.Add(GetUnit(handle));
        }
        return fabricatedUnits;
    }

    public void UpdateFabricatedUnit(EntityHandle handle, FabricatedUnit updatedUnit)
    {
        FabricatedUnit existingFabricatedUnit = GetUnit(handle);

        if (existingFabricatedUnit != null)
        {
            existingFabricatedUnit.Name = updatedUnit.Name;
            existingFabricatedUnit.Size = updatedUnit.Size;
            existingFabricatedUnit.NumberOfRooms = updatedUnit.NumberOfRooms;
            existingFabricatedUnit.UnitType = updatedUnit.UnitType;
        }
    }



}
