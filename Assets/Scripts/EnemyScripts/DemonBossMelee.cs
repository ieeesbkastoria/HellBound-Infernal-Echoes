using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using System;

public class DemonBossMelee: MonoBehaviour
{
    [Header ("Attack Melee Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    private bool con = false;

    [Header ("Ranged Attack Parameters")]
    public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
    [SerializeField] private float RangedattackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

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
    public EnemyAi Enemyai;
    private SpriteRenderer sprite;
    public Rigidbody2D rb;
    [SerializeField] private float NewVector;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= RangedattackCooldown) 
        {
        
            RangedAttack();
        }   
        //Attack only when player in sight
        if (PlayerInSight())
        {
            Debug.Log("PlayerInSight Function Entered");
            if (cooldownTimer >= attackCooldown)
            {
                con = true;
                cooldownTimer = 0;
                anim.SetTrigger("FireAttackEnter");
            }
        }
        else if (!con)
        {
            //anim.ResetTrigger("FireAttackEnter");
            anim.SetBool("Finish", true);
        } 

        if (con && PlayerInSight())
        {
            anim.SetBool("Finish", false);                    
            con = false;
        }
        //anim.SetBool("Finish", true);
        
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

    void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
        if (Enemyai.RLdirection == true) pos += transform.right * attackOffset.x;
        else if (Enemyai.RLdirection == false) pos += transform.right * -attackOffset.x;
        pos += transform.up * attackOffset.y;
    
		Gizmos.DrawWireSphere(pos, attackRange);
	}

    public void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);  
        } 
    }

    public void RangedAttack()
	{
		Vector3 pos = transform.position;
        if (Enemyai.RLdirection == true) pos += transform.right * attackOffset.x;
        else if (Enemyai.RLdirection == false) pos += transform.right * -attackOffset.x;
        pos += transform.up * attackOffset.y;
    

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			anim.SetTrigger("Fire");
		}
	}

    private void FireShooting()
    {
        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile2>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

     private bool TargetInDistance()
    {
        Debug.Log("TargetInDistance Function Entered");
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    void DieStatic()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
}