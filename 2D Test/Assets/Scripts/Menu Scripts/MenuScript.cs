using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using System.Linq;

public class MenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Dropdown resolutionDropdown;

    // List to hold all resolutions to add to dropdown
    List<Resolution> resolutions = new List<Resolution>();

    // Find all resolutions and populate the Resolution Dropdown with the values cast as strings
    void Start()
    {        
        // Find all unique resolutions
        var newResolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        // Set resolutions list to the sorted unique resolutions
        for (int i = 0; i < newResolutions.Length; i++)
        {
            resolutions.Add(newResolutions[i]);
        }

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;

        // Cast all resolutions to a string list
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);                      

            // Find current screen res and set current dropwdown index to it
            if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
            {
                Debug.Log(i);
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Test Scene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void LeaderboardButton()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Test Scene");
    }

    // Set master mixer volume to increments of 5 using options slider
    public void SetVolume(float volume)
    {
        float value = volumeSlider.value;
        float interval = 5.0f;
        value = Mathf.Round(value / interval) * interval;

        audioMixer.SetFloat("volume", value);
    }

    // Set quality acording to dropdown index
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Set fullscreen according to toggle value
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Set resolution according to dropdown index
    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }    
}
