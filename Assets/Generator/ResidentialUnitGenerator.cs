using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ResidentialUnitGenerator : MonoBehaviour
{


    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject doorPrefab;

    [SerializeField] private int _size = 5;
    private int _lastSize = 0;
    public float _wallWidth;

    private void Update()
    {
        if (_size != _lastSize) // If the size was changed in the inspector
        {
            _wallWidth = wallPrefab.GetComponent<Renderer>().bounds.size.x;
            GenerateRoom();
            _lastSize = _size; // Update the last size
        }
    }

    public void GenerateRoom()
    {
        // Clear existing room
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }

        float wallWidth = wallPrefab.GetComponent<Renderer>().bounds.size.x;
        for (int i = 0; i < _size; i++)
        {
            // take into account the width of the wall

            GameObject wall = Instantiate(wallPrefab, new Vector3(i, 0, 0), Quaternion.identity);
            //GameObject wall2 = Instantiate(wallPrefab, new Vector3(i * wallWidth + wallWidth / 2, 0, _size - wallWidth ), Quaternion.identity);
            //GameObject wall3 = Instantiate(wallPrefab, new Vector3(0 , 0, i * wallWidth + wallWidth / 2), Quaternion.Euler(0, 90, 0));
            //GameObject wall4 = Instantiate(wallPrefab, new Vector3(_size - wallWidth + wallWidth / 2, 0, i * wallWidth + wallWidth / 2), Quaternion.Euler(0, 90, 0));
        }

        float floorWidth = floorPrefab.GetComponent<Renderer>().bounds.size.z;
        for (int x = 0; x < _size; x++)
        {

            GameObject floor = Instantiate(floorPrefab, new Vector3(x, 0, 0 + floorWidth / 2), Quaternion.identity);

            for (int z = 0; z < _size; z++)
            {
            }
        }

      //  GameObject door = Instantiate(doorPrefab, new Vector3(_size / 2, 0, _size - 1), Quaternion.identity);
    }
        

    

}
