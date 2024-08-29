using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Enranged : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss_Health>().isInvulnerable = true;
        animator.GetComponent<Transform>().localScale = new Vector3(11, 11);
        animator.GetComponent<Boss_Weapon>().attackOffset = new Vector3(-3, -1);
        animator.GetComponent<Boss_Weapon>().attackRange = 2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss_Health>().isInvulnerable = false;
        animator.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
