using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    // The name of the scene you want to switch to
    [SerializeField] private string sceneName;

    // This function will be called when the button is clicked
    public void OnContinueButtonClick()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Load the scene with the specified name
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not assigned or is empty!");
        }
    }
}
