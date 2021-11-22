using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField] private float enemySpeed = 0f;
    [SerializeField] private float rotationMagnitud = 1f;
    private GameObject player;

    [SerializeField] private float rangeOfView = 1f;
    private bool iSeeU = false;

    enum TypesMoments { Mlineal, Mrotate}
    [SerializeField] private TypesMoments typeMovements;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find( "Player" );

        iSeeU = false;
    }

    // Update is called once per frame
    void FixUpdate()
    {
        // MoveEnemy(Vector3.forward);
       if (Vector3.Distance(transform.position, player.transform.position)<= rangeOfView)
        {
            iSeeU = true;
        }else { iSeeU = false; }


        if (iSeeU) {
            switch (typeMovements)
            {
                case TypesMoments.Mlineal:
                    MoveTowards1();
                    LookAtLerp(player);
                    break;

                case TypesMoments.Mrotate:
                    MoveTowards();
                    LookAtLerp(player);
                    break;

            } }

      
      
    }

    //movimiento lineal
    private void MoveEnemy(Vector3 direction)
    {
        transform.Translate(direction * enemySpeed * Time.deltaTime);

    }
    //movimiento seguir al player rotacion translate
    private void MoveTowards()
    {
        Vector3 direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * enemySpeed * Time.deltaTime);

    }
    private void LookAtLerp(GameObject lookObject) {

        Vector3 direction = lookObject.transform.position - transform.position;
        Quaternion newQuaternion = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newQuaternion, rotationMagnitud * Time.deltaTime);
          
            }

    //seguir al player lineal
    private void MoveTowards1()
    {
        Vector3 direction = player.transform.position - transform.position;
        transform.position += direction.normalized * enemySpeed * Time.deltaTime;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeOfView);
            }
}


