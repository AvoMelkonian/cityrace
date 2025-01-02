using UnityEngine;

public class SimpleSkyboxSwitcher : MonoBehaviour
{
    [Header("Skyboxes")]
    public Material daySkybox;   // Assign the Day Skybox Material
    public Material nightSkybox; // Assign the Night Skybox Material

    void Start()
    {
        // Default to Day Skybox
        SetDaySkybox();
    }
    public void toggleSkyBox()
    {
        if (RenderSettings.skybox == daySkybox)
        {
            RenderSettings.skybox = nightSkybox;
            DynamicGI.UpdateEnvironment();
        } else
        {
            RenderSettings.skybox = daySkybox;
            DynamicGI.UpdateEnvironment();
        }
    }
    public void SetDaySkybox()
    {
        RenderSettings.skybox = daySkybox;
        DynamicGI.UpdateEnvironment(); // Updates the lighting environment
    }

    public void SetNightSkybox()
    {
        RenderSettings.skybox = nightSkybox;
        DynamicGI.UpdateEnvironment(); // Updates the lighting environment
    }
}
