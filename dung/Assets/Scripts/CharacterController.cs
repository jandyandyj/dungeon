using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int lifePlayer = 3;
    public string namePlayer = "Mr. Blue";
    public float speedPlayer = 1f;
    // public GameObject swordPlayer;
    public Vector3 initPosition = new Vector3(4, 2, 1);
    //public Vector3 swordPosition = new Vector3(0, 0, 0.3f);
    public float cameraAxisX = -90f;

    //para animar
    [SerializeField] private Animator animPlayer;
    
    //variables para salto
    private Rigidbody rbFoot;
    [Range (200f,1000f)]
    [SerializeField] private float jumpForce = 1f;
    private bool isGrounded = true;
    private KeyInventory mgInventory;
    // Start is called before the first frame update
    void Start()
    {
       rbFoot =GetComponent<Rigidbody>();
        animPlayer.SetBool("IsRun", false);
        animPlayer.SetBool("IsJump", false);
        //transform.position = initPosition;
        //swordPlayer.GetComponent<SwordController>().SetSwordName("Espadon 9000");
        //swordPlayer.transform.position = transform.position + swordPosition;
        //swordPlayer.transform.localScale = transform.localScale;
        mgInventory = GetComponent<KeyInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        RotatePlayer();
        //swordPlayer.transform.position = transform.position + swordPosition;
        if (Input.GetKeyDown(KeyCode.Space))
        {if (isGrounded == true)
            {
                animPlayer.SetTrigger ("IsJump");
                Jump();
            }
          
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            UseItem();
        }

    }

    private void Move()
    {
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");


        if (ejeHorizontal != 0 || ejeVertical != 0)
        {
            animPlayer.SetBool("IsRun", true);
            transform.Translate(speedPlayer * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical));
        }
        else
        {
            animPlayer.SetBool("IsRun", false);
        }


    }

    private void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion angulo = Quaternion.Euler(0, cameraAxisX, 0);
        transform.localRotation = angulo;
    }

    private void Jump(){
        Debug.Log("saltalalinda");
        rbFoot.AddForce(0, 1* jumpForce, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Key"))
        {
            //Destroy(other.gameObject);
            GameObject Key = other.gameObject;
            Key.SetActive(false);
            mgInventory.AddInventoryOne(Key);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }

    private void UseItem()
    {
        GameObject Key = mgInventory.GetInventoryOne();
        Key.SetActive(true);
        Key.transform.position = transform.position + new Vector3(1f, 1f, 1f);
    }
}
