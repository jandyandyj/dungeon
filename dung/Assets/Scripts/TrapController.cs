using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private float startSpawn = 1f;
    [SerializeField] private float delaySpawn = 1f;
    [SerializeField] GameObject TrapArrow;
    // Start is called before the first frame update
    void Start()
    {
        Arrows();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Arrows()
    {
        Instantiate(TrapArrow, transform);
    }
}
