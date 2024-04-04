using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f; // Stop time
        pauseMenuUI.SetActive(true); // Activate pause menu UI
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Resume time
        pauseMenuUI.SetActive(false); // Deactivate pause menu UI
        isPaused = false;
    }

    public void Quit()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene("UI_Menu"); // Load the UI Menu scene
    }
}


