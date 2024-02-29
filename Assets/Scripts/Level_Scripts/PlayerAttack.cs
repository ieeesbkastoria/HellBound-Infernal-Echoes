using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            anim.SetBool("Is_attacking", true);
            
            Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);
            for (int i = 0; i < damage.Length; i++)
            {
                Destroy(damage[i].gameObject);
                Debug.Log("Damage Dealt");
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
