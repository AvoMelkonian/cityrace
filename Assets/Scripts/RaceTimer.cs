using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class RaceTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro timer display
    public float maxTime = 300f; // Maximum time limit in seconds (e.g., 5 minutes)
    public Action OnTimeLimitReached; // Callback for when the time limit is reached

    private float elapsedTime = 0f; // Time elapsed since the race started
    private bool isTimerRunning = false;

    void Update()
    {
        if (isTimerRunning)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the remaining time
            float remainingTime = Mathf.Clamp(maxTime - elapsedTime, 0, maxTime);

            // Format and display the remaining time
            timerText.text = FormatTime(remainingTime);

            // Check if the time limit is reached
            if (remainingTime <= 0)
            {
                isTimerRunning = false; // Stop the timer
                OnTimeLimitReached?.Invoke(); // Trigger the callback
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void StartTimer()
    {
        elapsedTime = 0f; // Reset the timer
        isTimerRunning = true; // Start the timer
    }

    public void StopTimer()
    {
        isTimerRunning = false; // Stop the timer
    }

    public void ResumeTimer()
    {
        isTimerRunning = true; // Resume the timer
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, milliseconds);
    }
}
