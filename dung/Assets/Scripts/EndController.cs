using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastStart();
    }

    private void RaycastStart()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.forward, out hit,4f))
        {
            Debug.Log("Time End");
            GameManager.score += 100;
            Debug.Log("Level 1 Completed! Your Score: " +GameManager.score);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector3.forward * 4f);
    }
}
