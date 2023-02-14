using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Keeps track of altmost al the game settings but not volume you can find that inside the volumemixer class.
/// </summary>
public class GameSettings : MonoBehaviour
{
    /// <summary>
    /// The resolution dropdown that holds al the resolution.
    /// </summary>
    [SerializeField]
    private TMP_Dropdown resolutionDropdown;

    /// <summary>
    /// Enables when fullscreen is toggled.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI toggleText;

    /// <summary>
    /// An array that holds al the resolutions.
    /// </summary>
    private Resolution[] resolutions;
    
    /// <summary>
    /// an bool that saves if the user is fullscreen or not.
    /// </summary>
    private bool isFullscreen;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        // Add resolutions to dropdown options
        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    /// <summary>
    /// Function for setting the resolution.
    /// </summary>
    /// <param name="resolutionIndex"></param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /// <summary>
    /// An function for toggeling the fullscreen mode.
    /// </summary>
    public void SetFullscreenToggle()
    {
        isFullscreen =! isFullscreen;
        toggleText.gameObject.SetActive(isFullscreen);
        Screen.fullScreen = isFullscreen;
    }
}