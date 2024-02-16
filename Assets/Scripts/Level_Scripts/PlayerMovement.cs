using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public CharacterController2D controller;
    public Animator animator;
    
    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("If Condition Passed");
            jump = true;
            Debug.Log("Jump set to True");
            animator.SetBool("IsJumping", true);
            Debug.Log("Animator Called");
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
}

