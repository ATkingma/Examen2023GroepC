using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
        SetMainVolume(saves.MasterVolume);
        musicVolumeSlider.value = saves.MusicVolume;
        SetMusicVolume(saves.MusicVolume);
        soundEffectsSlider.value = saves.SoundEffects;
        SetSoundEffectsVolume(saves.SoundEffects);
        UISoundSlider.value = saves.UIVolume;
        SetUIVolume(saves.UIVolume);
    }

    /// <summary>
    /// Sets the main volume.
    /// </summary>
    /// <param name="volume"></param>
    public void SetMainVolume(float volume)
    {
        SetVolumeLevel("Master", volume);
    }

    /// <summary>
    /// Sets the music volume.
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicVolume(float volume)
    {
        SetVolumeLevel("Music", volume);
    }

    /// <summary>
    /// Sets the sound effect Volume.
    /// </summary>
    /// <param name="volume"></param>
    public void SetSoundEffectsVolume(float volume)
    {
        SetVolumeLevel("Sound Effects", volume);
    }

    /// <summary>
    /// Sets the UI Volume.
    /// </summary>
    /// <param name="volume"></param>
    public void SetUIVolume(float volume)
    {
        SetVolumeLevel("UI", volume);
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
        SettingsManager.Instance.SaveVolume(mainVolumeSlider.value,musicVolumeSlider.value,soundEffectsSlider.value,UISoundSlider.value);
    }
}