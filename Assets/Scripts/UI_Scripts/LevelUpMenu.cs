using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public Text vitalityText;
    public Text dexterityText;
    public Text accuracyText;
    public Text strengthText;
    public Text enduranceText;
    public Text agilityText;
    public Text errorText;
    public PlayerAttack playerAttack;
    public PlayerCurrency playerCurrency; // Reference to PlayerCurrency script
    public PlayerLife playerLife;
    public PlayerEndurance playerEndurance;
    private int upgradeCost = 1; // Initial cost for upgrading a stat

    private int vitalityLevel = 1;
    private int dexterityLevel = 1;
    private int accuracyLevel = 1;
    private int strengthLevel = 1;
    private int enduranceLevel = 1;
    private int agilityLevel = 1;

   

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        accuracyText.text = "Accuracy: " + accuracyLevel;
        dexterityText.text = "Dexterity: " + dexterityLevel;
        vitalityText.text = "Vitality: " + vitalityLevel;
        strengthText.text = "Strength: " + strengthLevel;
        enduranceText.text = "Endurance: " + enduranceLevel;
        agilityText.text = "Agility: " + agilityLevel;
    }

    // Method to reset the error message text
    void ResetErrorText()
    {
        errorText.text = "";
    }

    // Increase the level of Vitality
    public void IncreaseVitality()
    {
        if (playerCurrency.GetCurrency() >= upgradeCost)
        {
            playerCurrency.AddCurrency(-upgradeCost);
            vitalityLevel++;
            upgradeCost++;
            playerLife.maxHealth = playerLife.maxHealth + 2;
            UpdateUI();
            ResetErrorText();
        }
        else
        {
            errorText.text = "Insufficient funds";
        }
    }

      public void IncreaseAccuracy()
    {
        if (playerCurrency.GetCurrency() >= upgradeCost)
        {
            playerCurrency.AddCurrency(-upgradeCost);
            accuracyLevel++;
            upgradeCost++;
            playerAttack.baseAttackRange = playerAttack.baseAttackRange + 0.5f;
            float newAttackRange = playerAttack.baseAttackRange;
            playerAttack.SetAttackRange(newAttackRange);
            UpdateUI();
            ResetErrorText();
        }
        else
        {
            errorText.text = "Insufficient funds";
        }
    }

      public void IncreaseDexterity()
    {
        if (playerCurrency.GetCurrency() >= upgradeCost)
        {
            playerCurrency.AddCurrency(-upgradeCost);
            dexterityLevel++;
            upgradeCost++;
            playerAttack.baseAttackCooldown = playerAttack.baseAttackCooldown - 0.1f;
            float newAttackCooldown = playerAttack.baseAttackCooldown;
            playerAttack.SetAttackSpeed(newAttackCooldown);
            UpdateUI();
            ResetErrorText();
        }
        else
        {
            errorText.text = "Insufficient funds";
        }
    }

    // Increase the level of Strength
    public void IncreaseStrength()
    {
        if (playerCurrency.GetCurrency() >= upgradeCost)
        {
            playerCurrency.AddCurrency(-upgradeCost);
            strengthLevel++;
            upgradeCost++;
            playerAttack.baseDamageAmount = playerAttack.baseDamageAmount + 1;
            int newDamageAmount = playerAttack.baseDamageAmount;
            playerAttack.SetAttackDamage(newDamageAmount);
            UpdateUI();
            ResetErrorText();
        }
        else
        {
            errorText.text = "Insufficient funds";
        }
    }

    // Increase the level of Endurance
    public void IncreaseEndurance()
    {
        if (playerCurrency.GetCurrency() >= upgradeCost)
        {
            playerCurrency.AddCurrency(-upgradeCost);
            enduranceLevel++;
            upgradeCost++;
            playerEndurance.maxEndurance = playerEndurance.maxEndurance + 2;
            UpdateUI();
            ResetErrorText();
        }
        else
        {
            errorText.text = "Insufficient funds";
        }
    }

    // Increase the level of Agility
    public void IncreaseAgility()
    {
        if (playerCurrency.GetCurrency() >= upgradeCost)
        {
            playerCurrency.AddCurrency(-upgradeCost);
            agilityLevel++;
            upgradeCost++;
            UpdateUI();
            ResetErrorText();
        }
        else
        {
            errorText.text = "Insufficient funds";
        }
    }

    // Method to clear the error message text when leaving the level up menu
    public void ClearErrorMessage()
    {
        ResetErrorText();
    }
}



