using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Building,
    Resident,
    Unit,
    Template,

    EntityType_Count,
}

public enum UnitType
{
    Residential,
    Commerical,
    Industrial,
    Public
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

public class Template : Entity
{
    public TemplateType TemplateType { get; set; }
    public int Size { get; set; }
    public int NumberOfRooms { get; set; }
    public UnitType UnitType { get; set; }
    // Other template properties...
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

    public void ResizeEntityManagerCapacity(int newCapacity)
    {
        // Ensure the new capacity is greater than the current one
        if (newCapacity <= totalEntityManagerCapacity)
        {
            Debug.LogError("New capacity must be greater than current capacity.");
            return;
        }

        // Create a new array with the new capacity
        EntityInfo[] newEntities = new EntityInfo[newCapacity];

        // Copy the contents of the old array to the new one
        for (int i = 0; i < totalEntityManagerCapacity; i++)
        {
            newEntities[i] = entities[i];
        }

        // Replace the old array with the new one
        entities = newEntities;

        // Update the capacity value
        totalEntityManagerCapacity = newCapacity;
    }


}
