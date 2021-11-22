using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public GameObject[] t;
    public Vector3 targetPos;
    

    [SerializeField] private float speed = 1f;
   private  Vector3 posA;
     private  Vector3 posB;
    private Vector3 origin;


    // Start is called before the first frame update
    void Start()
    {

        origin = transform.position;

        posA = transform.position;
    
        posB = targetPos;
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Back();

    }

    private void Move()
    {
        
        transform.position = Vector3.MoveTowards(posA,posB,speed*Time.deltaTime);
    }
    private void Back()
    {
        if (posA == posB)
        {
          transform.position= Vector3.MoveTowards(posA, origin, speed * Time.deltaTime);

           }else { Move(); }

    } }
