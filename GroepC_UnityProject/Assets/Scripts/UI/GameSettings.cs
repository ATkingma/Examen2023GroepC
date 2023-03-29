using GroepC.Data;
using GroepC.Managers;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GroepC.UI
{
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
        /// An bool that saves if the user is fullscreen or not.
        /// </summary>
        private bool isFullscreen;

        /// <summary>
        /// Resolution that wil be saved later.
        /// </summary>
        private Resolution currentResolutions;

        /// <summary>
        /// Sets the screen resolution.
        /// </summary>
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

            SavedSettings saves = SettingsManager.Instance.GetSavedSettings();
            saves ??= new SavedSettings();

            Screen.SetResolution(saves.SavedResolution.width, saves.SavedResolution.height, Screen.fullScreen);
            Screen.fullScreen = saves.IsFullScreen;
            isFullscreen = saves.IsFullScreen;
        }

        /// <summary>
        /// Function for setting the resolution.
        /// </summary>
        /// <param name="resolutionIndex">Resoltion options.</param>
        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            currentResolutions = resolution;
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        /// <summary>
        /// An function for toggeling the fullscreen mode.
        /// </summary>
        public void SetFullscreenToggle()
        {
            isFullscreen = !isFullscreen;
            toggleText.gameObject.SetActive(isFullscreen);
            Screen.fullScreen = isFullscreen;
        }

        /// <summary>
        /// Saves the settings of the current fullscreen mode and also of the current selected resolutions.
        /// </summary>
        public void SaveSettings() => SettingsManager.Instance.SaveGameSettings(currentResolutions, Screen.fullScreen);
    }
}