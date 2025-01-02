using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera menuCamera; // Reference to the Menu Camera
    public Camera playerCamera; // Reference to the Player Camera (Main Camera)

    void Start()
    {
        // Initially, enable only the Menu Camera
        menuCamera.enabled = true;
        playerCamera.enabled = false;
    }

    public void SwitchToPlayerCamera()
    {
        // Enable Player Camera and disable Menu Camera
        menuCamera.enabled = false;
        playerCamera.enabled = true;
    }
}
