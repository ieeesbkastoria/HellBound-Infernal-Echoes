using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public TextMeshProUGUI EnemyDeathsText; // UI Text to display enemy deaths
    public TextMeshProUGUI TimerText; // UI Text to display timer
    public GameObject gameWinScreen; // Reference to the win screen UI
    public EnemyLogic enemyLogic; // Reference to the EnemyLogic (if needed)

    private float timer;
    private bool isTimerRunning = false;
    private int enemyDeaths = 0; // Track enemy deaths

    void Start()
    {
        StartTimer();
        UpdateEnemyDeathsText(); // Update the display on start
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
        }
    }

    private void DisplayTimer()
    {
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");
        TimerText.text = "Time Taken: " + minutes + ":" + seconds;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        timer = 0f;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        DisplayTimer(); // Display the timer when stopped
    }

    public void restartGame()
    {
        DestroyPersistentObjects();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameWinScreen.SetActive(false);
    }

    private void DestroyPersistentObjects()
    {
        // Implementation of destroying persistent objects if needed
    }

    public void GameVictory()
    {
        gameWinScreen.SetActive(true);
        StopTimer();
    }

    // Method to be called when an enemy is killed
    public void EnemyKilled()
    {
        enemyDeaths++; // Increment the enemy deaths count
        UpdateEnemyDeathsText(); // Update the UI text
    }

    // Method to update the UI text for enemy deaths
    private void UpdateEnemyDeathsText()
    {
        EnemyDeathsText.text = "Enemies Slain: " + enemyDeaths; // Update the text display
    }
}



