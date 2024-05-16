using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    public static PlayerCurrency instance; // Singleton instance of the GameManager

    private int playerCurrency = 0; // Player's currency
    public Text currencyText; // Reference to the UI Text element for displaying currency
    public float LuckChance = 0.1f;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Make sure the GameManager persists between scenes
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Update the currency text initially
        UpdateCurrencyText();
    }

    // Method to add currency to the player
    public void AddCurrency(int amount)
    {
        // There's a 10% chance of dropping an extra 30% currency
        if (Random.value < LuckChance)
        {
            int extraCurrency = Mathf.RoundToInt(amount * 0.3f);
            playerCurrency += amount + extraCurrency;
            Debug.Log("Added " + amount + " currency (+ " + extraCurrency + " extra). Total: " + playerCurrency);
        }
        else
        {
            playerCurrency += amount;
            Debug.Log("Added " + amount + " currency. Total: " + playerCurrency);
        }

        UpdateCurrencyText();
    }

    // Method to retrieve the player's current currency
    public int GetCurrency()
    {
        return playerCurrency;
    }

    // Method to update the currency text on the screen
    private void UpdateCurrencyText()
    {
        if (currencyText != null)
        {
            currencyText.text = "Currency: " + playerCurrency;
        }
    }
}


