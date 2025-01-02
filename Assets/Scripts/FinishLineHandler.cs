using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineHandler : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UIManager to show the main menu
    public RaceTimer raceTimer; // Reference to the RaceTimer to stop the timer

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision detected with: {other.name}");

        // Check if the player car triggered the collider
        Transform current = other.transform;
        while (current != null)
        {
            if (current.CompareTag("PlayerCar"))
            {
                Debug.Log("Player crossed the finish line!");

                if (raceTimer != null)
                {
                    raceTimer.StopTimer();
                }

                if (uiManager != null)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                return; // Exit after processing the collision
            }
            current = current.parent; // Move up the hierarchy
        }
    }
}