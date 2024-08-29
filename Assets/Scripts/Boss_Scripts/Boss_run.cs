using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_run : StateMachineBehaviour
{   
    
    public float speed = 2.5f;
    public float attackRange = 3f;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float BlockCooldown;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Ranged attack is activate")]
    [SerializeField] private bool DoRangedAttack = true;
    [Header("Block attack is activate")]
    [SerializeField] private bool DoBlockAttack = false;
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    Boss_Health boss_Health;
    Boss_Weapon boss_Weapon;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        boss_Health = animator.GetComponent<Boss_Health>();
        boss_Weapon = animator.GetComponent<Boss_Weapon>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       cooldownTimer += Time.deltaTime;
       boss.LookAtPlayer();

       Vector2 target = new Vector2(player.position.x, rb.position.y);
       Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime); 
       rb.MovePosition(newPos);

       if (Vector2.Distance(player.position, rb.position) <= attackRange)
       {
            animator.SetTrigger("Attack");
            DoRangedAttack = true;
       }

      if (DoRangedAttack) // 2nd way (Input.GetKeyDown(KeyCode.U))
       {
        if (boss_Health.health == 80 || boss_Health.health == 60 || boss_Health.health == 40 || boss_Health.health == 20 || boss_Health.health == 100)
        {
           if (cooldownTimer >= attackCooldown)
           {
            cooldownTimer = 0;
            animator.SetTrigger("Attack2");
            DoRangedAttack = false;
           } 
        }
       }
       
       // Block player attack with a cooldown
       /*if (DoBlockAttack)
       {
        if(animator.GetComponent<PlayerAttack>().playerEndurance.CheckEndurance(1))
        {
           if (cooldownTimer >= BlockCooldown)
           {
            cooldownTimer = 0;
            animator.SetTrigger("Block");
           }
       }
       }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Attack2");
        if (DoBlockAttack) animator.ResetTrigger("Block");
    }
}
