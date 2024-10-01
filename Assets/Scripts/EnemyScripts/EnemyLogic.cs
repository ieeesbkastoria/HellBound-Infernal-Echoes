using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int startingHealth = 100; // Starting health of the enemy
    private int currentHealth; // Current health of the enemy
    public int currencyOnKill = 10; // Amount of currency to give to the player when this enemy is killed

    private LogicScript logicScript; // Reference to the LogicScript

    private void Start()
    {
        currentHealth = startingHealth; // Initialize current health to starting health
        // Find the LogicScript in the scene
        logicScript = FindObjectOfType<LogicScript>();
    }

    private void Die()
    {
        // Add currency to the player
        PlayerCurrency.instance.AddCurrency(currencyOnKill);

        // Notify LogicScript about the enemy's death
        if (logicScript != null)
        {
            logicScript.EnemyKilled(); // Call the method to update the count
        }

        // Destroy this enemy GameObject
        Destroy(gameObject);
    }

    // Method to damage the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Deduct damage from current health
        Debug.Log("Current Health is " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // If health reaches zero or below, call Die() method
        }
    }
}


