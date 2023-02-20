using System;
using UnityEngine;

namespace GroepC.Data
{
    /// <summary>
    /// An class that can be saved as json.
    /// </summary>
    [Serializable]
    public class SavedSettings
    {
        /// <summary>
        /// <see cref="SavedSettings"/>.
        /// </summary>
        public SavedSettings()
        {
            MasterVolume = 0;
            MusicVolume = 0;
            SoundEffects = 0;
            UIVolume = 0;
            IsFullScreen = true;
            SavedResolution = Screen.currentResolution;
        }

        /// <summary>
        /// The saved volume of the master Volume
        /// </summary>
        public float MasterVolume;

        /// <summary>
        /// The saved volume of the music Volume
        /// </summary>
        public float MusicVolume;

        /// <summary>
        /// The saved volume of the sound effects
        /// </summary>
        public float SoundEffects;

        /// <summary>
        /// The saved volume of the UI Volume
        /// </summary>
        public float UIVolume;

        /// <summary>
        /// A saved bool that shows if the player is fulscreen
        /// </summary>
        public bool IsFullScreen;

        /// <summary>
        /// The saved Resolution
        /// </summary>
        public Resolution SavedResolution;
    }
}
