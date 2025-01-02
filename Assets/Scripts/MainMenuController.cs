using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject carSelectionUI; // Reference to car selection UI
    public Camera menuCamera; // Camera for looking at the city
    public Transform cityView; // Position for city view

    void Start()
    {
        carSelectionUI.SetActive(false);
    }

    public void StartRace()
    {
        carSelectionUI.SetActive(true); // Show car selection
        gameObject.SetActive(false); // Hide main menu
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
