using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int health;
    public Animator anim;
    public Rigidbody2D rb;

    [SerializeField] private bool wantDie = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start ()
    {
        health = maxHealth;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TakeDamage(20);
        }
    }
	//public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		//if (isInvulnerable)
			//return;

		health -= damage;
		if (health <= 0)
		{
            anim.SetTrigger("Dead");
            rb.bodyType = RigidbodyType2D.Static;
            if (wantDie) Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}

}