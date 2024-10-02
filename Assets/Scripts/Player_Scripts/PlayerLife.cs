using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Vector2 CheckPointPosition;
    public LogicScript logic;
    private Rigidbody2D rb;
    private PlayerMovement movement;

    // Define player's health points
    public int healings = 3;
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
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        CheckPointPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) Healing();
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

    }

    void OnTriggerEnter2D(Collider2D collision)
{
    // Check if the collided object has the "Win" tag
    if (collision.gameObject.CompareTag("Win"))
    {
        // Call the GameVictory method in the logic component
        logic.GameVictory();
        
        // Call the Die method (if necessary for the current behavior)
        Die();
    }
}


    public void TakeDamage(int damage)
    {
        currentHealth--;
        SetHealth(currentHealth);

       

        if (currentHealth <= 0)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        
    }

       public void Healing()
    {
            if(healings <= 3 && healings > 0)
        {
            if(currentHealth > 0 && currentHealth != 3)
            {
                Debug.Log("Healed");
                healings--;
                currentHealth++;
                SetHealth(currentHealth);
            }  
        }
    } 

     IEnumerator Respawn(float duration)
    {
        rb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(duration);
        transform.position = CheckPointPosition;

        //Health
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);

        if(movement.spin == true){transform.localScale = new Vector3(-10, 10, 2);}
        else transform.localScale = new Vector3(10, 10, 2);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        CheckPointPosition = pos;

    }
 

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(Respawn(0.5f));
    }
    
}


