using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Boss_Weapon: MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private int damage;
    [SerializeField] private int EnrangedDamage;

    [Header ("Attack2 Parameters")]
    [SerializeField] private Transform[] firepoint;
    [SerializeField] private GameObject[] Summoned;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    //References
    [Header("Other")]
    public Animator anim;
    public PlayerLife  playerHealth;

    [Header("Diffrent versions")]
    [SerializeField] private bool IsGuided;

    [Header("Melee attack")]
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

    //Melee attack1
	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerLife>().TakeDamage(damage);
		}
	}

    //Melee  Enranged Attack
	public void EnrangedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerLife>().TakeDamage(EnrangedDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}

    //Ranged attack2
    public void Attack2()
    {
        for (int i = 0; i < Summoned.Length; i++)
        {
            Summoned[i].transform.position = firepoint[i].position;
            if (IsGuided == true) Summoned[i].GetComponent<EnemyProjectile>().ActivateProjectile();
            else Summoned[i].GetComponent<EnemyProjectile2>().ActivateProjectile();
        }
    }

}