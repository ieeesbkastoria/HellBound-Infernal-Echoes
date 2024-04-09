using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public Text vitalityText;
    public Text strengthText;
    public Text enduranceText;
    public Text agilityText;
    public Text errorText;
    public PlayerCurrency playerCurrency; // Reference to PlayerCurrency script
    private int upgradeCost = 1; // Initial cost for upgrading a stat

    private int vitalityLevel = 1;
    private int strengthLevel = 1;
    private int enduranceLevel = 1;
    private int agilityLevel = 1;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
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



