using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Function to be called when the button is clicked
    public void StartGame()
    {
        // Load the "Main" scene
        SceneManager.LoadScene("Layer 1");
    }
}

