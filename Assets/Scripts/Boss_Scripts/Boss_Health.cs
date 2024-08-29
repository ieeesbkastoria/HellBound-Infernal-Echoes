using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    [SerializeField] private bool IsEnranged = false;

    public bool StageOne = true;
    public int maxHealth = 100;
	public int health;
    public  BossHealthBar healthBar;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start ()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TakeDamage(10);
        }

    }
	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;
        healthBar.SetHealth(health);

        if (IsEnranged && health <= 50)
        {
            anim.SetBool("IsEnranged", true);
            StageOne = false;
        }

		if (health <= 0)
		{
            healthBar.SetHealth(0);
            anim.SetTrigger("Exit");
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}

}