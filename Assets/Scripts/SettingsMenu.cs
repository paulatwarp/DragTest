using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public AudioMixerGroup MusicMixer, SFXMixer;
    public TMP_Text masterLabel, musicLabel, sfxLabel;
    public Slider masterSlider, musicSlider, sfxSlider;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle, vsyncToggle;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
        }
        else
        {
            vsyncToggle.isOn = true;
        }

        float vol = 0f;
        AudioMixer.GetFloat("volume", out vol);
        masterSlider.value = vol;
        AudioMixer.GetFloat("musicvolume", out vol);
        musicSlider.value = vol;
        AudioMixer.GetFloat("sfxvolume", out vol);
        sfxSlider.value = vol;

        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
    }
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
        masterLabel.text = Mathf.RoundToInt(masterSlider.value +80).ToString();
        PlayerPrefs.SetFloat("volume", masterSlider.value);
    }
    public void SetMusicVolume(float MusicVolume)
    {
        AudioMixer.SetFloat("musicvolume", MusicVolume);
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        PlayerPrefs.SetFloat("musicvolume", musicSlider.value);
    }
    public void SetSFXVolume(float SFXVolume)
    {
        AudioMixer.SetFloat("sfxvolume", SFXVolume);
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
        PlayerPrefs.SetFloat("sfxvolume", sfxSlider.value);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenToggle.isOn;

        if (vsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}