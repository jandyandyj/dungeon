using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkFoward();
        WalkBack();
        WalkLeft();
        WalkRight();
      
    }

    void WalkFoward()
    {
        if (Input.GetKeyDown(KeyCode.W))
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
}
