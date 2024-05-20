using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public Transform attackLocation;
    public LayerMask enemies;

    // Variables for attack parameters
    public float baseAttackRange = 1.5f;
    public int baseDamageAmount = 1;
    public float baseAttackCooldown = 0.5f;
    public PlayerEndurance playerEndurance;

    // Modified attack parameters
    private float attackRange;
    private int damageAmount;
    private float attackCooldown;

    private float nextAttackTime = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();

        // Initialize attack parameters
        attackRange = baseAttackRange;
        damageAmount = baseDamageAmount;
        attackCooldown = baseAttackCooldown;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {  
                if (playerEndurance.CheckEndurance(1))
                {
                    playerEndurance.Is_Performing_Action = true;
                    playerEndurance.DecreaseEndurance(1);
                    Attack();  
                    playerEndurance.Is_Performing_Action = false;
                    nextAttackTime = Time.time + attackCooldown;
                }
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        Debug.Log("Attack trigger set");

        Collider2D[] damageColliders = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);
        foreach (Collider2D collider in damageColliders)
        {
            EnemyLogic enemyLogic = collider.GetComponent<EnemyLogic>();
            if (enemyLogic != null)
            {
                enemyLogic.TakeDamage(damageAmount);
                Debug.Log("Damage Dealt");
            }
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }

    // Method to set attack parameters from LevelUpMenu script
    public void SetAttackRange(float newAttackRange)
    {
        attackRange = newAttackRange;
    }

    public void SetAttackDamage(int newDamageAmount)
    {
        damageAmount = newDamageAmount;     
    }

    public void SetAttackSpeed(float newAttackCooldown)
    {
        attackCooldown = newAttackCooldown;
    }


}


