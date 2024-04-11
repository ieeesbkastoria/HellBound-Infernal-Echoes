using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int startingHealth = 100; // Starting health of the enemy
    private int currentHealth; // Current health of the enemy
    public int EnemyDeaths = 0;

    public int currencyOnKill = 10; // Amount of currency to give to the player when this enemy is killed

    private void Start()
    {
        currentHealth = startingHealth; // Initialize current health to starting health
    }

    private void Die()
    {
        // Add currency to the player
        EnemyDeaths++;
        PlayerCurrency.instance.AddCurrency(currencyOnKill);

        // Destroy this enemy GameObject
        Destroy(gameObject);
    }

    // Method to damage the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Deduct damage from current health
        Debug.Log("Current Health is" + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // If health reaches zero or below, call Die() method
        }
    }
}

