using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject levelUpMenuUI; 
    public GameObject blackoutPanel; // Reference to the opaque black panel
    public LevelUpMenu levelUpMenu; // Reference to the LevelUpMenu script
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (levelUpMenuUI.activeSelf)
            {
                Back();
            }
            else
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
    }

    void Pause()
    {
        Time.timeScale = 0f; 
        pauseMenuUI.SetActive(true); 
        levelUpMenuUI.SetActive(false); // Deactivate the level up menu UI
        blackoutPanel.SetActive(true); // Activate the opaque black panel
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f; 
        pauseMenuUI.SetActive(false); 
        levelUpMenuUI.SetActive(false); // Deactivate the level up menu UI
        blackoutPanel.SetActive(false); // Deactivate the opaque black panel
        isPaused = false;
    }

    public void Quit()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("UI_Menu"); 
    }

    public void OpenLevelUpMenu()
    {
        if (pauseMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(false);
            isPaused = false;
        }

        levelUpMenuUI.SetActive(true);
        blackoutPanel.SetActive(true); // Activate the opaque black panel
        levelUpMenu.ClearErrorMessage(); // Call the function to clear error message
    }

    public void Back()
    {
        levelUpMenuUI.SetActive(false);

        pauseMenuUI.SetActive(true);
        blackoutPanel.SetActive(true); // Activate the opaque black panel
        isPaused = true;
    }

    public void restartGame()
    {
        // Reset the time scale to ensure the game runs normally after restart
        Time.timeScale = 1f;

        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

