using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // For UI Elements

public class AreaTransitions : MonoBehaviour
{
    public string scenePathOrName;  // Scene name or path
    public GameObject confirmationUI;  // UI to ask the player for confirmation
    private bool playerInTrigger = false;  // Tracks if player is in the trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the player
        if (other.tag == "Player" && !other.isTrigger)
        {
            playerInTrigger = true;  // Player has entered the trigger
            confirmationUI.SetActive(true);  // Show the confirmation UI
            StartCoroutine(WaitForPlayerInput());  // Start the coroutine to wait for input
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset the trigger if the player leaves
        if (other.tag == "Player" && !other.isTrigger)
        {
            playerInTrigger = false;
            confirmationUI.SetActive(false);  // Hide the confirmation UI when the player leaves
        }
    }

    // Coroutine to wait for the player to press X
    IEnumerator WaitForPlayerInput()
    {
        // Wait for player input while in the trigger
        while (playerInTrigger)
        {
            // If player presses the X key
            if (Input.GetKeyDown(KeyCode.X))
            {
                confirmationUI.SetActive(false);  // Hide the UI

                // Load the scene if it's in the build settings
                if (SceneUtility.GetBuildIndexByScenePath(scenePathOrName) != -1)
                {
                    SceneManager.LoadScene(scenePathOrName, LoadSceneMode.Single);
                }
                else
                {
                    Debug.LogError("Scene not found in Build Settings: " + scenePathOrName);
                }
                yield break;  // Exit the coroutine
            }

            // Continue to wait until next frame
            yield return null;
        }
    }
}

