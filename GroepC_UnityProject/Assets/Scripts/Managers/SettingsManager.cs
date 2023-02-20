using GroepC.Data;
using UnityEngine;

namespace GroepC.Managers
{
    /// <summary>
    /// This managedes how where and how to settings are getting saved.
    /// </summary>
    public class SettingsManager : MonoBehaviour
    {
        /// <summary>
        /// The instance for this class.
        /// </summary>
        public static SettingsManager Instance;

        /// <summary>
        /// The instance of this class.
        /// </summary>
        public static SettingsManager InstanceInstance;

        /// <summary>
        /// The Save name of this class that will be used for the playerPrefs.
        /// </summary>
        const string playerPrefName = "SettingsManager";

        /// <summary>
        /// Sets the instance for this class.
        /// </summary>
        private void Awake()
        {
            Instance = this;

            string savedjson = PlayerPrefs.GetString(playerPrefName);
            if (savedjson == string.Empty)
                SetupSaves();
        }

        /// <summary>
        /// This function will setup the saves so there can always something to be get.
        /// </summary>
        private void SetupSaves()
        {
            string newValue = JsonUtility.ToJson(new SavedSettings());
            PlayerPrefs.SetString(playerPrefName, newValue);
        }

        /// <summary>
        /// Saved the volume of al given variables if one is empty is filled in with 0.
        /// </summary>
        /// <param name="master">The master sound value.</param>
        /// <param name="music">The music sound value.</param>
        /// <param name="soundEffects">Sound effects sound value.</param>
        /// <param name="ui">UI sound value.</param>
        public void SaveVolume(float master = 0, float music = 0, float soundEffects = 0, float ui = 0)
        {
            string jsonString = PlayerPrefs.GetString(playerPrefName);
            SavedSettings newSettings = JsonUtility.FromJson<SavedSettings>(jsonString);
            newSettings.MasterVolume = master;
            newSettings.MusicVolume = music;
            newSettings.SoundEffects = soundEffects;
            newSettings.UIVolume = ui;

            SaveSettings(newSettings);
        }

        /// <summary>
        /// Saves the resultion and the fullscreen ration.
        /// </summary>
        /// <param name="res">The resolution settings.</param>
        /// <param name="fullScreen">Defines the fullscreen.</param>
        public void SaveGameSettings(Resolution res, bool fullScreen)
        {
            string jsonString = PlayerPrefs.GetString(playerPrefName);
            SavedSettings newSettings = JsonUtility.FromJson<SavedSettings>(jsonString);
            newSettings.IsFullScreen = fullScreen;
            newSettings.SavedResolution = res;

            SaveSettings(newSettings);
        }

        /// <summary>
        /// Saves the settings to json.
        /// </summary>
        /// <param name="newSettings">The new settings.</param>
        public void SaveSettings(SavedSettings newSettings)
        {
            string jsonString = JsonUtility.ToJson(newSettings);
            PlayerPrefs.SetString(playerPrefName, jsonString);
        }

        /// <summary>
        /// Gets the settings from json.
        /// </summary>
        /// <returns>The saved settings.</returns>
        public SavedSettings GetSavedSettings()
        {
            string jsonString = PlayerPrefs.GetString(playerPrefName);
            return JsonUtility.FromJson<SavedSettings>(jsonString);
        }
    }
}
