using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    EntityType_Base,
    EntityType_Star,

    EntityType_Player,
    EntityType_Enemy,

    EntityType_PlayerBullet,

    EntityType_EnemyBullet,

    EntityType_PlayerLaserCharge,
    EntityType_PlayerLaserShot,

    EntityType_ShotBar,

    EntityType_KillCount,

    EntityType_Count,
}



public class Entity
{
    public EntityHandle handle;
}

public class EntityInfo
{
    public int indexInBuffer;
    public int generation;

    public EntityType type;
}

public class EntityHandle
{
    public int idLocationInsideInfo;
    public int generation;

    public EntityType type;
};

public class EntityTypeBuffer
{
    public int count;
    public int capacity;
    public int sizeInBytes;

    public Entity[] entities;
};

//struct EntityManager
//{
//    int totalEntityManagerCapacity;
//    int nextID;

//    pubEntityTypeBuffer buffers[EntityType_Count];
//    EntityInfo* entities;
//};


//struct Entity
//{
//    Vector2 postion;
//    Vector2 size;

//    //Sprite* sprite;

//    bool toDelete;

//    EntityHandle handle;
//};


public class EntityManager : MonoBehaviour
{

    public int totalEntityManagerCapacity;
    private int nextEntityId;

    EntityTypeBuffer[] buffers;
    EntityInfo[] entities;

    public EntityFactory entityFactory;


}
    //private Dictionary<int, Index> entities = new Dictionary<int, Index>();
   

    //public class Handle
    //{
    //    public int id;

    //    public Handle(int id)
    //    {
    //        this.id = id;
    //    }
    //}
     
    //public class Index
    //{
    //    public GameObject gameObject;

    //    public Index(GameObject gameObject)
    //    {
    //        this.gameObject = gameObject;
    //    }
    //}

    //public Handle AddEntity(GameObject gameObject)
    //{
    //    int id = nextEntityId++;
    //    entities.Add(id, new Index(gameObject));
    //    return new Handle(id);
    //}

    //public Index GetEntity(Handle handle)
    //{
    //    if (entities.TryGetValue(handle.id, out Index index))
    //    {
    //        return index;
    //    }
    //    return null;
    //}

    //public void RemoveEntity(Handle handle)
    //{
    //    entities.Remove(handle.id);
    //}



    //public void PlaceEntity(ObjectPlacerController objectPlacerController)
    //{
    //    entityFactory.CreateEntity(objectPlacerController);
    //}



//}
