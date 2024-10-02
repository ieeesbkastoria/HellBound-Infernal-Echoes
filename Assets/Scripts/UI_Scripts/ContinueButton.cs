using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    // List of GameObjects you want to persist across scenes (e.g., Player, UI elements, etc.)
    [SerializeField] private GameObject[] persistentObjects;

    // Reference to the win screen GameObject
    [SerializeField] private GameObject winScreen;

    // Reference to the player object
    [SerializeField] private GameObject player;

    // Coordinates for player positioning in the new scene
    [SerializeField] private float xCoordinate;
    [SerializeField] private float yCoordinate;
    [SerializeField] private float zCoordinate;

    private void Start()
    {
        // Ensure the ContinueButton persists across scenes
        DontDestroyOnLoad(gameObject);

        // Make the specified GameObjects persistent across scenes
        foreach (var obj in persistentObjects)
        {
            DontDestroyOnLoad(obj);
        }
    }

    // This function will be called when the button is clicked
    public void OnContinueButtonClick()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = currentScene.buildIndex + 1;  // Get the next scene index

        // Check if there is a next scene
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Deactivate the win screen
            if (winScreen != null)
            {
                winScreen.SetActive(false);
            }
            else
            {
                Debug.LogError("Win screen is not assigned!");
            }

            // Subscribe to the sceneLoaded event to move the player after the scene is loaded
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Load the next scene using the next scene index
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("No more scenes to load!");
        }
    }

    // This is called after the new scene has been loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (player != null)
        {
            // Move the player to the specified coordinates
            player.transform.position = new Vector3(xCoordinate, yCoordinate, zCoordinate);

            // Reset the healing count on the player
            PlayerLife playerLife = player.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.healings = 3; // Reset healing count to 3
            }
            else
            {
                Debug.LogError("PlayerLife component not found on the player!");
            }
        }
        else
        {
            Debug.LogError("Player object is missing!");
        }

        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}






