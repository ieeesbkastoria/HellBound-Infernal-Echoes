using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public CharacterController2D controller;
    public PlayerEndurance playerEndurance;
    public Animator animator;
    
    public float runSpeed = 40f;
    public bool spin = false;

    bool jump = false;
    bool crouch = false;

    float horizontalMove = 0f;
    public int DoNotMinedMe;

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalMove < 0){DoNotMinedMe = 2; spin = true;  Debug.Log("Invert"); }  
        else if (horizontalMove > 0){DoNotMinedMe = 1; spin = false;} 
        else DoNotMinedMe = 3;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            
           if (playerEndurance.CheckEndurance(2))
           {
                jump = true;
                playerEndurance.Is_Performing_Action = true;
                playerEndurance.DecreaseEndurance(2);
                animator.SetBool("IsJumping", true);
                playerEndurance.Is_Performing_Action = false;
                
           }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsCrouching", true);
            crouch = true;
        } else if (Input.GetKeyUp(KeyCode.S))
        {
             animator.SetBool("IsCrouching", false);
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && controller.canDash)
        {  
            if (playerEndurance.CheckEndurance(3))
            {
              playerEndurance.Is_Performing_Action = true;
              playerEndurance.DecreaseEndurance(3);
              StartCoroutine(controller.Dash());
              playerEndurance.Is_Performing_Action = false;
            }
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


