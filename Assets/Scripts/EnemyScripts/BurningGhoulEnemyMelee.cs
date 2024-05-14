using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class BurningGhoulEnemyMelee: MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    [Header("Other")]
    public Animator anim;
    public PlayerLife  playerHealth;
    public Transform target;
    public float activateDistance = 50f;
    public EnemyAi isJumping1;
    private SpriteRenderer sprite;
    [SerializeField] private float NewVector;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /*if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(NewVector, NewVector, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-NewVector, NewVector, 1f);
        }*/

        /*if (TargetInDistance())
        {
            Debug.Log("If Condition Passed TargetInDistance = true");
            anim.SetBool("Moving", true);
        }
        else
        {
            Debug.Log("Else Passed TargetInDistance = false");
            anim.SetBool("Moving", false);
        }*/
        

        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight
        if (PlayerInSight())
        {
            
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("kabbom");
            }
        }

        /*if (isJumping1.isJumping)
        {
            anim.SetTrigger("Jump");
        }*/

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        

       if (hit.collider != null) playerHealth = hit.transform.GetComponent<PlayerLife>();

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);  
        } 
    }

     private bool TargetInDistance()
    {
        Debug.Log("TargetInDistance Function Entered");
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }
}