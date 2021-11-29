using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text textKey;
    [SerializeField] private KeyInventory mgInventory;
    

    // Start is called before the first frame update
    void Start()
    {
        textKey.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFoodUI();
    }

    void UpdateFoodUI()
    {
        int[] keyCount = mgInventory.GetKeyQuantity();
      
        textKey.text = "x" + keyCount[0];
        textKey.text = "x" + keyCount[1];

    }
}
