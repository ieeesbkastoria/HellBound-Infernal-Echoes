using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public LogicScript logic;
    private Rigidbody2D rb;

    public int maxHealth = 3;
    public int currentHealth;

    public Slider slider;

    public float knockbackForce = 10;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

       fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {Debug.Log("Enemy Hit");}
            // Deduct health points when colliding with traps or enemies
            currentHealth--;
            SetHealth(currentHealth);

            // Apply knockback force
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            rb.velocity = Vector2.zero;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

            if (currentHealth <= 0)
            {
                Die();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            logic.GameVictory();
            Die();
        }
    }

    public void TakeDamage()
    {
        currentHealth--;
        SetHealth(currentHealth);

       

        if (currentHealth <= 0)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
}


