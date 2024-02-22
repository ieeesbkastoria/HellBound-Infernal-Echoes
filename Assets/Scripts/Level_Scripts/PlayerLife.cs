using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public LogicScript logic;
    private Rigidbody2D rb;

    // Define player's health points
    public int maxHealth = 3;
    public int  currentHealth;

    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
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
            // Deduct health points when colliding with traps or enemies
            currentHealth--;
            SetHealth(currentHealth);
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

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
}

