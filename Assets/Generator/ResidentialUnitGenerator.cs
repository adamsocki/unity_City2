using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//[ExecuteInEditMode]
public class ResidentialUnitGenerator : MonoBehaviour
{

    public class Room
    {
        public Vector3 Position { get; set; }
        public Vector3 Size { get; set; }

        public Room(float x, float y, float z, float width, float height, float depth)
        {
            Position = new Vector3(x, y, z);
            Size = new Vector3(width, height, depth);
        }
    }

    private List<Room> _rooms = new List<Room>();

    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject doorPrefab;

    [SerializeField] private int _size = 5;
    [SerializeField] private int _size_y = 120;
    private int _lastSize = 0;
    public float _wallWidth;

  


    private void Start()
    {
        float wallHeight = wallPrefab.GetComponent<Renderer>().bounds.size.y;
        Room initialRoom = new Room(0, 2, 0, 10, wallHeight, 10);
        _rooms.Add(initialRoom);
        Room nextRoom = new Room(0, 5 + wallHeight, 0, 10, wallHeight, 10);
        _rooms.Add(nextRoom);
        for (int i = 0; i < 10; i++)
        {
            //Room roomToSplit = _rooms[Random.Range(0, _rooms.Count)];
            //SplitRoom(roomToSplit);
        }

        foreach (Room room in _rooms)
        {
            RenderRoom(room);
        }

    }
    private void Update()
    {

        
    }

    public void RenderRoom(Room room)
    {
        float wallWidth = wallPrefab.GetComponent<Renderer>().bounds.size.x;
        float wallHeight = wallPrefab.GetComponent<Renderer>().bounds.size.y;
        float wallThickness = wallPrefab.GetComponent<Renderer>().bounds.size.z;

        float doorHeight = doorPrefab.GetComponent<Renderer>().bounds.size.y;

        for (int i = 0; i < room.Size.x; i++)
        {
            GameObject wall_x1 = Instantiate(wallPrefab, new Vector3(room.Position.x + i, room.Position.y + wallHeight / 2, room.Position.z + wallThickness / 2), Quaternion.identity);
            GameObject wall_x2 = Instantiate(wallPrefab, new Vector3(room.Position.x + i, room.Position.y + wallHeight / 2, room.Position.z + room.Size.z - wallThickness / 2), Quaternion.identity);
        }

        for (int i = 0; i < room.Size.z; i++)
        {
            GameObject wall_y1 = Instantiate(wallPrefab, new Vector3(room.Position.x - wallWidth / 2 - wallThickness / 2, room.Position.y + wallHeight / 2, room.Position.z + i + wallWidth / 2), Quaternion.Euler(0, 90, 0));
            GameObject wall_y2 = Instantiate(wallPrefab, new Vector3(room.Position.x + room.Size.x - wallWidth / 2 - wallThickness / 2, room.Position.y + wallHeight / 2, room.Position.z + i + wallWidth / 2), Quaternion.Euler(0, 90, 0));
        }

        float floorWidth = floorPrefab.GetComponent<Renderer>().bounds.size.z;
        for (int x = 0; x < room.Size.x; x++)
        {
            for (int z = 0; z < room.Size.z; z++)
            {
                GameObject floor = Instantiate(floorPrefab, new Vector3(room.Position.x + x, room.Position.y, room.Position.z + z + floorWidth / 2), Quaternion.identity);
            }
        }

        // Instantiate door at the center of the room, you may want to update this according to your specific needs
        GameObject door = Instantiate(doorPrefab, new Vector3(room.Position.x + room.Size.x / 2, room.Position.y + doorHeight / 2, room.Position.z + wallThickness / 2), Quaternion.identity);
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
