using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    public int damageAmount;

    private void Start()
    {
        anim = GetComponent<Animator>();
        damageAmount = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            anim.SetBool("Is_attacking", true);
        
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
        else
        {
            anim.SetBool("Is_attacking", false);
        }
}


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
