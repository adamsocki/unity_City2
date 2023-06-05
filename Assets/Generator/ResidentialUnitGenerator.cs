using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ResidentialUnitGenerator;

public class Unit_Room
{
    public int ID { get; set; }
    public List<Room> Rooms { get; set; }

    public Unit_Room(int id)
    {
        ID = id;
        Rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }
}


//[ExecuteInEditMode]
public class ResidentialUnitGenerator : MonoBehaviour
{

    public GameObject parent;

    public class Room
    {
        public Vector3 Position { get; set; }
        public Vector3 Size { get; set; }
        public Vector3 UnitsToRender { get; set; }

        public Room(float x, float y, float z, float width, float height, float depth, Vector3 unitsToRender)
        {
            Position = new Vector3(x, y, z);
            Size = new Vector3(width, height, depth);
            UnitsToRender = new Vector3(unitsToRender.x, unitsToRender.y, unitsToRender.z);
        }
    }

    private List<Room> _rooms = new List<Room>();
    private List<GameObject> renderedRooms = new List<GameObject>();

    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject doorPrefab;

    [SerializeField] private int _size = 5;
    [SerializeField] private int _size_y = 120;
    private int _lastSize = 0;
    public float _wallWidth;

  
    public void DeleteRender()
    {
        foreach (GameObject renderedObject in renderedRooms)
        {
            Destroy(renderedObject);
        }
        _rooms.Clear();
    }

    public void StartUnitGenerator(int roomCount)
    {
        float wallHeight = wallPrefab.GetComponent<Renderer>().bounds.size.y;
        Room initialRoom = new Room(parent.transform.position.x, parent.transform.position.y + 2, parent.transform.position.z, 20, wallHeight, 20, new Vector3(1,1,1));
        _rooms.Add(initialRoom);
       // Room nextRoom = new Room(0, 5 + wallHeight, 0, 10, wallHeight, 10);
       // _rooms.Add(nextRoom);
        for (int i = 0; i < roomCount; i++)
        {
            bool final = false;
            Room roomToSplit = _rooms[Random.Range(0, _rooms.Count)];
            
            SplitRoom(roomToSplit);
        }

        foreach (Room room in _rooms)
        {
            RenderRoom(room);
        }

    }


    public void RenderRoom(int room)
    {

    }

    public void RenderRoom(Room room)
    {
        float wallWidth = wallPrefab.GetComponent<Renderer>().bounds.size.x;
        float wallHeight = wallPrefab.GetComponent<Renderer>().bounds.size.y;
        float wallThickness = wallPrefab.GetComponent<Renderer>().bounds.size.z;

        float doorWidth = doorPrefab.GetComponent<Renderer>().bounds.size.x;
        float doorHeight = doorPrefab.GetComponent<Renderer>().bounds.size.y;
        float doorThickness = doorPrefab.GetComponent<Renderer>().bounds.size.z;


        for (int i = 0; i < room.UnitsToRender.x; i++)
        {
            GameObject wall_x1 = Instantiate(wallPrefab, new Vector3(room.Position.x + i, room.Position.y + wallHeight / 2, room.Position.z + wallThickness / 2), Quaternion.identity, parent.transform);
            GameObject wall_x2 = Instantiate(wallPrefab, new Vector3(room.Position.x + i, room.Position.y + wallHeight / 2, room.Position.z + room.Size.z - wallThickness / 2), Quaternion.identity, parent.transform);
            renderedRooms.Add(wall_x1);
            renderedRooms.Add(wall_x2);
        }

        for (int i = 0; i < room.UnitsToRender.z; i++)
        {
            GameObject wall_z1 = Instantiate(wallPrefab, new Vector3(room.Position.x - wallWidth / 2 - wallThickness / 2, room.Position.y + wallHeight / 2, room.Position.z + i + wallWidth / 2), Quaternion.Euler(0, 90, 0), parent.transform);
            GameObject wall_z2 = Instantiate(wallPrefab, new Vector3(room.Position.x + room.Size.x - wallWidth / 2 - wallThickness / 2, room.Position.y + wallHeight / 2, room.Position.z + i + wallWidth / 2), Quaternion.Euler(0, 90, 0), parent.transform);
            renderedRooms.Add(wall_z1);
            renderedRooms.Add(wall_z2);
        }

        float floorWidth = floorPrefab.GetComponent<Renderer>().bounds.size.z;
        for (int x = 0; x < room.Size.x; x++)
        {
            for (int z = 0; z < room.Size.z; z++)
            {
                GameObject floor = Instantiate(floorPrefab, new Vector3(room.Position.x + x, room.Position.y, room.Position.z + z + floorWidth / 2), Quaternion.identity);
                renderedRooms.Add(floor);
            }
        }

        // Instantiate door at the center of the room, you may want to update this according to your specific needs
        //bool doorDirection = Random.value < 0.5f;

        //if (doorDirection) 
        //{
        //    GameObject door = Instantiate(doorPrefab, new Vector3(room.Position.x + room.Size.x / 2, room.Position.y + doorHeight / 2, room.Position.z + wallThickness / 2), Quaternion.identity);
        //}
        //else
        //{
        //    GameObject door = Instantiate(doorPrefab, new Vector3(room.Position.x - doorWidth / 2 - wallThickness / 2, room.Position.y + doorHeight / 2, room.Position.z + room.Size.z / 2), Quaternion.Euler(0, 90, 0));
        //}
    }
     

    private void SplitRoom(Room room)
    {
        float wallWidth = wallPrefab.GetComponent<Renderer>().bounds.size.x;
        float wallHeight = wallPrefab.GetComponent<Renderer>().bounds.size.y;
        float wallThickness = wallPrefab.GetComponent<Renderer>().bounds.size.z;

        float doorWidth = doorPrefab.GetComponent<Renderer>().bounds.size.x;
        float doorHeight = doorPrefab.GetComponent<Renderer>().bounds.size.y;
        float doorThickness = doorPrefab.GetComponent<Renderer>().bounds.size.z;

        // Decide whether to split vertically or horizontally
        // This can be more advanced, for example by checking the proportions of the room
        bool splitVertically = Random.value < 0.5f;

        // The room will be split in the middle, either vertically or horizontally
        // For simplicity, the new rooms will be of equal size, but you could add more randomness here
        float splitPosition;
        Room room1, room2;

        if (splitVertically)
        {
            // Split vertically
            splitPosition = room.Size.x / 2;
            Debug.Log("V");
            Debug.Log("V " + splitPosition);
            Debug.Log("room.size.x " + room.Size.x);
            Vector3 unitsForRender = room.Size;
            unitsForRender.x = splitPosition;

            room1 = new Room(room.Position.x, room.Position.y, room.Position.z, splitPosition , room.Size.y, room.Size.z, unitsForRender);
            room2 = new Room(room.Position.x + splitPosition , room.Position.y, room.Position.z, room.Size.x - splitPosition , room.Size.y, room.Size.z, unitsForRender);
        }
        else
        {
            // Split horizontally 
            splitPosition = room.Size.z / 2;
            Debug.Log("H");
            Debug.Log("H " + splitPosition);
            Debug.Log("room.size.z " + room.Size.z);
            Vector3 unitsForRender = room.Size;
            unitsForRender.z = splitPosition;

            room1 = new Room(room.Position.x, room.Position.y, room.Position.z, room.Size.x, room.Size.y, splitPosition + wallThickness, unitsForRender);
            room2 = new Room(room.Position.x, room.Position.y, room.Position.z + splitPosition , room.Size.x, room.Size.y, room.Size.z - splitPosition, unitsForRender);
           
        }

        // Remove the original room and add the two new ones
        _rooms.Remove(room);
        _rooms.Add(room1);
        _rooms.Add(room2);
    }



    public void GenerateRoom()
    {
       

        float wallWidth = wallPrefab.GetComponent<Renderer>().bounds.size.x;
        float wallHeight = wallPrefab.GetComponent<Renderer>().bounds.size.y;
        float wallThickness = wallPrefab.GetComponent<Renderer>().bounds.size.z;

        float doorHeight = doorPrefab.GetComponent<Renderer>().bounds.size.y;


        for (int i = 0; i < _size; i++)
        {
            // take into account the width of the wall 

            GameObject wall_x1 = Instantiate(wallPrefab, new Vector3(i, 2 + wallHeight / 2,       0 + wallThickness / 2), Quaternion.identity);
            GameObject wall_x2 = Instantiate(wallPrefab, new Vector3(i, 2 + wallHeight / 2, _size_y - wallThickness / 2), Quaternion.identity);
             
            
        }

        for (int i = 0; i < _size_y; i++)
        {
            GameObject wall_y1 = Instantiate(wallPrefab, new Vector3(    0 - wallWidth / 2 - wallThickness / 2, 2 + wallHeight / 2, i + wallWidth / 2), Quaternion.Euler(0, 90, 0));
            GameObject wall_y2 = Instantiate(wallPrefab, new Vector3(_size - wallWidth / 2 - wallThickness / 2, 2 + wallHeight / 2, i + wallWidth / 2), Quaternion.Euler(0, 90, 0));
        }



        float floorWidth = floorPrefab.GetComponent<Renderer>().bounds.size.z;
        for (int x = 0; x < _size; x++)
        {


            for (int z = 0; z < _size_y; z++)
            {

                GameObject floor = Instantiate(floorPrefab, new Vector3(x, 2, z + floorWidth / 2), Quaternion.identity);
            }
        }   


        GameObject door = Instantiate(doorPrefab, new Vector3(3, 2 + doorHeight / 2, 0 + wallThickness / 2), Quaternion.identity);

    }


        
      //  GenerateAttachedRoom(new Vector3(door.transform.position.x + wallThickness, door.transform.position.y, door.transform.position.z));

    public void GenerateAttachedRoom(Vector3 newRoomStartPos)
    {
        float wallWidth = wallPrefab.GetComponent<Renderer>().bounds.size.x;
        float wallHeight = wallPrefab.GetComponent<Renderer>().bounds.size.y;
        float wallThickness = wallPrefab.GetComponent<Renderer>().bounds.size.z;
        float floorWidth = floorPrefab.GetComponent<Renderer>().bounds.size.z;
        float doorHeight = doorPrefab.GetComponent<Renderer>().bounds.size.y;

        for (int i = 0; i < _size; i++)
        {
            GameObject wall_x1 = Instantiate(wallPrefab, new Vector3(newRoomStartPos.x + i, 2 + wallHeight / 2, newRoomStartPos.z - wallThickness / 2), Quaternion.identity);
            GameObject wall_x2 = Instantiate(wallPrefab, new Vector3(newRoomStartPos.x + i, 2 + wallHeight / 2, newRoomStartPos.z - _size_y + wallThickness / 2), Quaternion.identity);
        }

        for (int i = 0; i < _size_y; i++)
        {
            GameObject wall_y1 = Instantiate(wallPrefab, new Vector3(newRoomStartPos.x - wallWidth / 2 - wallThickness / 2, 2 + wallHeight / 2, newRoomStartPos.z - i - wallWidth / 2), Quaternion.Euler(0, 90, 0));
            GameObject wall_y2 = Instantiate(wallPrefab, new Vector3(newRoomStartPos.x + _size - wallWidth / 2 - wallThickness / 2, 2 + wallHeight / 2, newRoomStartPos.z - i - wallWidth / 2), Quaternion.Euler(0, 90, 0));
        }

        for (int x = 0; x < _size; x++)
        {
            for (int z = 0; z < _size_y; z++)
            {
                GameObject floor = Instantiate(floorPrefab, new Vector3(newRoomStartPos.x + x, 2, newRoomStartPos.z - z - floorWidth / 2), Quaternion.identity);
            }
        }

        GameObject door = Instantiate(doorPrefab, new Vector3(newRoomStartPos.x + 3, 2 + doorHeight / 2, newRoomStartPos.z - wallThickness / 2), Quaternion.identity);
    }




}
