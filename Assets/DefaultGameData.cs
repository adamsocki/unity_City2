using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGameData : MonoBehaviour
{
    public List<EntityHandle> PortOfEntryHandles_Default { get; private set; }

    public void AddEntityToDataList(EntityHandle entityHandle, List<EntityHandle> entityHandleList)
    {
        entityHandleList.Add(entityHandle);
    }

    public void RemoveEntityToDataList(EntityHandle entityHandle, List<EntityHandle> entityHandleList)
    {
        entityHandleList.Remove(entityHandle);
    }

}
