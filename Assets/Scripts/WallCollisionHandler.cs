using UnityEngine;
using UnityEngine.SceneManagement;

public class WallCollisionHandler : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UIManager for returning to the main menu

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something collided with the invisible wall: " + other.name); // Log the collider name

        // Check if the root object or any parent has the PlayerCar tag
        Transform current = other.transform;
        while (current != null)
        {
            if (current.CompareTag("PlayerCar"))
            {
                Debug.Log("Player hit the invisible wall! Returning to main menu...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //uiManager.ShowStartMenu(); // Call the main menu method
                return;
            }
            current = current.parent; // Move up the hierarchy
        }

        Debug.Log("No PlayerCar tag found in the hierarchy.");
    }
}
