using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class InstantAreaTransition : MonoBehaviour
{
    // Public field to specify the name of the scene to load
    [SerializeField] private string sceneName;

    // This method will be called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // You can add a condition to check if the player stepped on the collider
        if (other.CompareTag("Player"))
        {
            // Check if the scene name is set
            if (!string.IsNullOrEmpty(sceneName))
            {
                // Load the scene specified in the sceneName field
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("Scene name is not set!");
            }
        }
    }
}
