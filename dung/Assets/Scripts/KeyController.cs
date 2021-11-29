using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    
    [SerializeField] private GameManager.typesKey typeKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public GameManager.typesKey GettypeKey()
    {
        return typeKey;

    }
}
