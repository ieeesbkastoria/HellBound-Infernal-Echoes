using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEndurance : MonoBehaviour
{
    public Slider slider; // Reference to the UI slider for the endurance bar
    public float maxEndurance = 100f; // Maximum endurance value
    public float currentEndurance; // Current endurance value
    public bool Is_Performing_Action = false;

    float increaseTimer = 0f;
    float increaseInterval = 1f; 

    void Start()
    {
        currentEndurance = maxEndurance; // Initialize current endurance to max
        UpdateEnduranceBar(); // Update the UI to reflect the initial value
    }

      void Update()
    {
        // If not performing action and stamina is not at max
        if (!Is_Performing_Action && currentEndurance != maxEndurance)
        {
            // Increment the timer
            increaseTimer += Time.deltaTime;
        
            // Check if the timer exceeds the interval
            if (increaseTimer >= increaseInterval)
            {
                // Increase stamina and reset the timer
                IncreaseEndurance(1);
                increaseTimer = 0f;
            }
        }
    }

    // Function to reduce endurance by a specified amount
    public void DecreaseEndurance(float amount)
    {
        currentEndurance -= amount;
        currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance); // Ensure endurance doesn't go below 0 or above max
        UpdateEnduranceBar(); // Update UI
    }

    // Function to increase endurance by a specified amount
    public void IncreaseEndurance(float amount)
    {
        currentEndurance += amount;
        currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance); // Ensure endurance doesn't go below 0 or above max
        UpdateEnduranceBar(); // Update UI
    }

    // Function to update the UI to reflect the current endurance value
    void UpdateEnduranceBar()
    {
        slider.value = currentEndurance; // Update slider value (0 to 1)
    }

    public bool CheckEndurance(int EnduranceAmount)
    {
        if (currentEndurance >= EnduranceAmount)
        {
            return true;
        }
        else
        {
           return false;
        }
    }
}
