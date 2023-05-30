using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ListScrollView : MonoBehaviour
{
   
    public GameObject itemPrefab;
    public int numberOfItems;

    private void Start()
    {
        PopulateList();
    }

    public void PopulateList()
    {
        if (numberOfItems == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        else
        {
            gameObject.SetActive(true);
        }

        for (int i = 0; i < numberOfItems; i++)
        {
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            newItem.transform.SetParent(transform, false);
            // Set data on the item here if needed
        }
    }

    public void ClearList() 
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
            gameObject.SetActive(false);
        }
    }

    public void AddItem()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        GameObject newItem = Instantiate(itemPrefab) as GameObject;
        newItem.transform.SetParent(transform, false);
        // Set data on the item here if needed

    }

    

}
