using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startMenuCanvas;
    public GameObject countdownCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject gameplayCanvas;
    public CameraSwitcher cameraSwitcher; // Reference to CameraSwitcher

    private bool isPaused = false;
    private RaceTimer raceTimer;

    void Start()
    {
        raceTimer = FindAnyObjectByType<RaceTimer>(); // Find the RaceTimer script
        ShowStartMenu();
    }
    public void ShowStartMenu()
    {
        startMenuCanvas.SetActive(true);
        countdownCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);

        Time.timeScale = 0f; // Freeze game
    }
    public void StartRace()
    {
        startMenuCanvas.SetActive(false);
        countdownCanvas.SetActive(true);

        // Switch to the player camera
        cameraSwitcher.SwitchToPlayerCamera();

        // Start the countdown, then begin the race
        StartCoroutine(FindAnyObjectByType<CountdownController>().StartCountdown(() =>
        {
            gameplayCanvas.SetActive(true);
            raceTimer.StartTimer(); // Start the timer
            Time.timeScale = 1f; // Resume game
        }));
    }
    public void PauseGame()
    {
        if (!isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            raceTimer.StopTimer(); // Pause the timer
            Time.timeScale = 0f; // Freeze game
            isPaused = true;
        }
    }
    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        raceTimer.ResumeTimer(); // Resume the timer
        Time.timeScale = 1f; // Resume game
        isPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
    public void EndRace()
    {
        Debug.Log("Race Completed! Returning to main menu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
