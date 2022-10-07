using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer AudioMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            AudioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        }
        if (PlayerPrefs.HasKey("musicvolume"))
        {
            AudioMixer.SetFloat("musicvolume", PlayerPrefs.GetFloat("musicvolume"));
        }
        if (PlayerPrefs.HasKey("sfxvolume"))
        {
            AudioMixer.SetFloat("sfxvolume", PlayerPrefs.GetFloat("sfxvolume"));
        }
    }
}
