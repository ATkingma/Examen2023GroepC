using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SavedSettings
{
    public SavedSettings()
    {
        MasterVolume = 0;
        MusicVolume = 0;
        SoundEffects = 0;
        UIVolume = 0;
        IsFullScreen = true;
        SavedResolution = Screen.currentResolution;
    }

    public float MasterVolume;

    public float MusicVolume;

    public float SoundEffects;

    public float UIVolume;

    public bool IsFullScreen;

    public Resolution SavedResolution;
}
