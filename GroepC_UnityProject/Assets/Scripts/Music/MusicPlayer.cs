using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Music player holds all the behaviour for the background.
/// </summary>
public class MusicPlayer : MonoBehaviour
{

    /// <summary>
    /// The audiosource of the music player this is the audioplayer where the audio wil be played on.
    /// </summary>
    [SerializeField]
    private AudioSource audioSource;

    /// <summary>
    /// All the audio clips that the music player can play.
    /// </summary>
    [SerializeField]
    private AudioClip[] audioClips;

    /// <summary>
    /// The index of the current hold clip out of the audioclips list.
    /// </summary>
    private int currentClip = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextClip();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    /// <summary>
    /// Plays the next clip and adds currentClip.
    /// </summary>
    void PlayNextClip()
    {
        if (currentClip >= audioClips.Length)
        {
            currentClip = 0;
        }

        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        currentClip++;
    }
}
