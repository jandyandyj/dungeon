using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInventory : MonoBehaviour
{
    // Start is called before the first frame update

    private Stack inventoryOne;
    private Queue inventoryTwo;
    Dictionary<string, GameObject> inventoryThree;

    //agregado ui key
    [SerializeField] private int[] KeyQuantity = { 0, 0 };

    void Start()
    {
        inventoryOne = new Stack();
        inventoryTwo = new Queue();
        inventoryThree = new Dictionary<string, GameObject>();


       

    }
    public void CountKey(GameObject key)
    {
        KeyController k = key.GetComponent<KeyController>();

        switch (k.GettypeKey())
        {
            case GameManager.typesKey.Silver:
                KeyQuantity[0]++;

                break;
            case GameManager.typesKey.Gold:
                KeyQuantity[1]++;

                break;
            default:
                Debug.Log("No se puede contar");
                break;

        }
    }

    public int [] GetKeyQuantity()
    {
        return KeyQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void AddInventoryOne(GameObject key)
    {
        inventoryOne.Push(key);
    }

    public GameObject GetInventoryOne()
    {
        return inventoryOne.Pop() as GameObject;
    }

    public void SeeInventoryOne()
    {
        Debug.Log(inventoryOne.ToString());
        foreach (var key in inventoryOne)
        {
            Debug.Log(key.ToString());
        }
    }

    public bool InventoryOneHas()
    {
        return inventoryOne.Count > 0;
    }
    //-------------------------- INVENTORY QUEQUE -------------------------//
    public void AddInventoryTwo(GameObject item)
    {
        inventoryTwo.Enqueue(item);
    }

    public GameObject GetInventoryTwo()
    {
        return inventoryTwo.Dequeue() as GameObject;
    }

    public void SeeInventoryTwo()
    {
        Debug.Log(inventoryTwo.ToString());
        foreach (var item in inventoryTwo)
        {
            Debug.Log(item.ToString());
        }
    }

    public bool InventoryTwoHas()
    {
        return inventoryTwo.Count > 0;
    }

    //-------------------------- INVENTORY DIC -------------------------//
    public void AddInventoryThree(string key, GameObject item)
    {
        inventoryThree.Add(key, item);
    }

    public GameObject GetInventoryThree(string key)
    {
        return inventoryThree[key] as GameObject;
    }

    public void SeeInventoryThree()
    {
        Debug.Log(inventoryThree.ToString());
        foreach (var item in inventoryThree)
        {
            Debug.Log(item.ToString());
        }
    }

    public bool InventoryThreeHas()
    {
        return inventoryThree.Count > 0;
    }

}
