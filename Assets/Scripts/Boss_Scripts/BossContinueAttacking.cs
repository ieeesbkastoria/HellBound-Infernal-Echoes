using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossContinueAttacking : StateMachineBehaviour
{
    public float attackRange = 3f; 

    Transform player;
    Rigidbody2D rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (Vector2.Distance(player.position, rb.position) <= attackRange)
       {
            animator.SetBool("ContinueAttacking", true);
       } 
       else
       {
            animator.SetBool("ContinueAttacking", false);
       }
    }
}
