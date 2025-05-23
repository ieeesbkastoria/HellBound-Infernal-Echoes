using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Block : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss_Health>().isInvulnerable = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss_Health>().isInvulnerable = false;
        if (animator.GetComponent<Boss_Health>().StageOne) animator.SetBool("RLBlock", true);
        else animator.SetBool("RLBlock", false);
    }
}
