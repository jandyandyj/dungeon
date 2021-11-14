using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject enemyPrefab;
    public GameObject[] ArrowPrefab;
    public float startDelay = 2;
    public float spawnInterval = 1.5f;
    public Vector3 scale;

    void Start()
    {
        InvokeRepeating("Arrow", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Arrow()
    {
        int arrowIndex = Random.Range(0, ArrowPrefab.Length);
        Instantiate(ArrowPrefab[arrowIndex], transform.position, ArrowPrefab[arrowIndex].transform.rotation);
    }

}