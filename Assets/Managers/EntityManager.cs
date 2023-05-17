using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Building,
    EntityType_Count,
}



public class Entity
{
    public EntityHandle handle;
    // Common properties for all entities...
}

public class Building : Entity
{
    // Unique properties for buildings...
    public int floors;
    public string address;
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
    public static EntityManager Instance { get; private set; }

    public int totalEntityManagerCapacity = 10;
    private int nextEntityId;

    EntityTypeBuffer[] buffers;
    EntityInfo[] entities;

    // public EntityFactory entityFactory;

    void Start()
    {
        // Initialize buffers
        buffers = new EntityTypeBuffer[System.Enum.GetNames(typeof(EntityType)).Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            buffers[i] = new EntityTypeBuffer()
            {
                count = 0,
                capacity = 10, // start with some initial capacity
                entities = new Entity[10]
            };
        }

        entities = new EntityInfo[totalEntityManagerCapacity];
        nextEntityId = 0;
    }

    public EntityHandle AddEntity(EntityType type, Entity entity)
    {
        // Find the buffer for this entity type
        EntityTypeBuffer buffer = buffers[(int)type];

        // Check if there is room in the buffer, resize if necessary
        if (buffer.count == buffer.capacity)
        {
            // Resize the buffer, e.g. by doubling its size
            Entity[] newEntities = new Entity[buffer.capacity * 2];
            buffer.entities.CopyTo(newEntities, 0);
            buffer.entities = newEntities;
            buffer.capacity *= 2;
        }

        // Add the entity to the buffer
        buffer.entities[buffer.count] = entity;
        buffer.count++;

        // Create and populate an EntityInfo
        EntityInfo info = new EntityInfo
        {
            indexInBuffer = buffer.count - 1,
            generation = 0,
            type = type
        };

        // Add the EntityInfo to the entities array
        entities[nextEntityId] = info;

        // Create and return an EntityHandle
        EntityHandle handle = new EntityHandle
        {
            idLocationInsideInfo = nextEntityId,
            generation = 0,
            type = type
        };

        nextEntityId++;
        return handle;
    }

    public Entity GetEntity(EntityHandle handle)
    {
        // Validate the handle
        if (handle.idLocationInsideInfo < 0 || handle.idLocationInsideInfo >= nextEntityId)
        {
            Debug.LogError("Invalid handle.");
            return null;
        }

        // Get the EntityInfo
        EntityInfo info = entities[handle.idLocationInsideInfo];

        // Check the generation
        if (info.generation != handle.generation)
        {
            Debug.LogError("Stale handle.");
            return null;
        }

        // Get the entity from the buffer
        return buffers[(int)info.type].entities[info.indexInBuffer];
    }

    public void RemoveEntity(EntityHandle handle)
    {
        // Validate the handle
        if (handle.idLocationInsideInfo < 0 || handle.idLocationInsideInfo >= nextEntityId)
        {
            Debug.LogError("Invalid handle.");
            return;
        }

        // Get the EntityInfo
        EntityInfo info = entities[handle.idLocationInsideInfo];

        // Check the generation
        if (info.generation != handle.generation)
        {
            Debug.LogError("Stale handle.");
            return;
        }

        // Get the buffer
        EntityTypeBuffer buffer = buffers[(int)info.type];

        // Move the last entity in the buffer to fill the gap
        buffer.entities[info.indexInBuffer] = buffer.entities[buffer.count - 1];

        // If there's more than one entity in the buffer, update the EntityInfo for the moved entity
        if (buffer.count > 1)
        {
            entities[buffer.entities[info.indexInBuffer].handle.idLocationInsideInfo].indexInBuffer = info.indexInBuffer;
        }

        // Decrease the buffer's count
        buffer.count--;

        // Update the EntityInfo's generation to invalidate all existing handles to this entity
        info.generation++;
    }

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
