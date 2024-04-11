using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public TextMeshProUGUI EnemyDeathsText;
    public TextMeshProUGUI TimerText;
    public GameObject gameWinScreen;
    public EnemyLogic enemyLogic;

    private float timer; 
    private bool isTimerRunning = false; 

    void Start() 
    {
        StartTimer();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameVictory()
    {
        gameWinScreen.SetActive(true);
        EnemyDeathsText.text = "Enemies Slain: " + enemyLogic.EnemyDeaths;
        StopTimer();
    }
}


