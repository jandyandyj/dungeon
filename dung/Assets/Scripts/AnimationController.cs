using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    //
    //para animar
    [SerializeField] private Animator animPlayer;
    private float Delay = 1f;
    //variables para salto
    private Rigidbody rbFoot;
    [Range(200f, 1000f)]
    [SerializeField] private float jumpForce = 1f;
    private bool isGrounded = true;
    //
    private bool CrouchActive = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //
        rbFoot = GetComponent<Rigidbody>();
        animPlayer.SetBool("IsRun", false);
        animPlayer.SetBool("IsJump", false);
        //transform.position = initPosition;
        //swordPlayer.GetComponent<SwordController>().SetSwordName("Espadon 9000");
        //swordPlayer.transform.position = transform.position + swordPosition;
        //swordPlayer.transform.localScale = transform.localScale;
        //
    }

    // Update is called once per frame
    void Update()
    {
        WalkFoward();
        WalkBack();
        WalkLeft();
        WalkRight();
        Jump();
        Attack();
        Crouch();
        WalkFowardCrouch();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                animPlayer.SetTrigger("IsJump");
                Jump();
            }

        }
    }

    void WalkFoward()
    {
        if (CrouchActive == false && Input.GetKeyDown(KeyCode.W))
        {
            anim.Play("walk");

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.Play("stand");
        }
    }

    void WalkBack()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.Play("walkback");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.Play("stand");
        }
    }

    void WalkLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("walkleft");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.Play("stand");
        }
    }

    void WalkRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.Play("walkrigth");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.Play("stand");
        }
    }



    private void Attack()
    {
        //rbFoot.AddForce(0, 1 * jumpForce, 0);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.Play("attack");
        }
    }

    private void Jump()
    {
        //rbFoot.AddForce(0, 1 * jumpForce, 0);
        if (Input.GetKey(KeyCode.Space))
        {
            anim.Play("jump");
            transform.position += new Vector3(1f, 0f, 0f) * Delay * Time.deltaTime;
        }
    
    }

    /// End Normal Moves
    /// //////////////////////
    /// Crocuh Move
    private void Crouch()
    {
        //rbFoot.AddForce(0, 1 * jumpForce, 0);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.Play("crouch");
            CrouchActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.Play("stand");
        }
    }

    void WalkFowardCrouch()
    {
        if (CrouchActive == true && Input.GetKeyDown(KeyCode.W))
        {
            anim.Play("walk_crouch");
        }
        else if (CrouchActive == true && Input.GetKeyUp(KeyCode.W))
        {
            anim.Play("crouch");
            CrouchActive = false;
        }
    }
}

