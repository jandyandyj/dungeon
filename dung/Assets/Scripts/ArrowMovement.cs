using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    private float initialSpeed = 0f;
    public Vector3 scale;
    public Vector3 position;
    private int life = 1;
    public float Speed;
    public int Damage;
    public float liveCanon = 1f;

    // Start is called before the first frame update
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Arrow Move");
        transform.position += new Vector3(0.03f, 0f, 0f) * Speed;

        liveCanon -= Time.deltaTime;
        if (liveCanon < 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }


    }
    void MoveArrow()
    {
        //Move
        Debug.Log("Arrow Start");
        transform.localScale = scale;
        transform.position = position;
        initialSpeed = Speed;
    }
    void ArrowDamage()
    {
        //-Life
        life = life - Damage;
        Debug.Assert(life > 0);
        //Debug.Log("Ship Lifes Reduced: " + damageLife);
        //Debug.Log("Ship Total Lifes: " + life);
    }
}