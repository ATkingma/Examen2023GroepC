using GroepC.Data;
using GroepC.Managers;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace GroepC.UI
{
    /// <summary>
    /// Manages the volume settings of the game.
    /// </summary>
    public class VolumeMixer : MonoBehaviour
    {
        /// <summary>
        /// The Audiomixer that contains al the volume information.
        /// </summary>
        [SerializeField]
        private AudioMixer audioMixer;

        /// <summary>
        /// MainSlider for the main volume.
        /// </summary>
        [SerializeField]
        private Slider mainVolumeSlider;

        /// <summary>
        /// MusicSlider for the music volume.
        /// </summary>
        [SerializeField]
        private Slider musicVolumeSlider;

        /// <summary>
        /// SoundEffectSlider for the Sound Effect volume.
        /// </summary>
        [SerializeField]
        private Slider soundEffectsSlider;

        /// <summary>
        /// UISlider for the UI volume.
        /// </summary>
        [SerializeField]
        private Slider UISoundSlider;

        private void Start()
        {
            SavedSettings saves = SettingsManager.Instance.GetSavedSettings();
            mainVolumeSlider.value = saves.MasterVolume;
            SetVolumeLevel("Master", saves.MasterVolume);
            musicVolumeSlider.value = saves.MusicVolume;
            SetVolumeLevel("Music", saves.MusicVolume);
            soundEffectsSlider.value = saves.SoundEffects;
            SetVolumeLevel("Sound Effects", saves.SoundEffects);
            UISoundSlider.value = saves.UIVolume;
            SetVolumeLevel("UI", saves.UIVolume);
        }

        /// <summary>
        /// Sets the main volume.
        /// </summary>
        /// <param name="volume"></param>
        public void SetMainVolume()
        {
            SetVolumeLevel("Master", mainVolumeSlider.value);
        }

        /// <summary>
        /// Sets the music volume.
        /// </summary>
        /// <param name="volume"></param>
        public void SetMusicVolume()
        {
            SetVolumeLevel("Music", musicVolumeSlider.value);
        }

        /// <summary>
        /// Sets the sound effect Volume.
        /// </summary>
        /// <param name="volume"></param>
        public void SetSoundEffectsVolume()
        {
            SetVolumeLevel("Sound Effects", soundEffectsSlider.value);
        }

        /// <summary>
        /// Sets the UI Volume.
        /// </summary>
        /// <param name="volume"></param>
        public void SetUIVolume()
        {
            SetVolumeLevel("UI", UISoundSlider.value);
        }

        /// <summary>
        /// GEts the volume level.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        private float GetVolumeLevel(string parameterName)
        {
            float volume;
            bool result = audioMixer.GetFloat(parameterName, out volume);
            if (result)
            {
                return volume;
            }
            else
            {
                return 0f;
            }
        }

        /// <summary>
        /// Sets the volume level of an audiomixer group.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="volume"></param>
        private void SetVolumeLevel(string parameterName, float volume)
        {
            audioMixer.SetFloat(parameterName, volume);
        }

        /// <summary>
        /// Saves the volume of the sliders.
        /// </summary>
        public void SaveVolume()
        {
            SettingsManager.Instance.SaveVolume(mainVolumeSlider.value, musicVolumeSlider.value, soundEffectsSlider.value, UISoundSlider.value);
        }
    }
}