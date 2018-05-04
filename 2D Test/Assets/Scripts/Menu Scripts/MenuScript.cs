using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Dropdown resolutionDropdown;

    public Text userText;
    private string userName;
    private string userScore;

    Resolution[] resolutions;

    // Find all resolutions and populate the Resolution Dropdown with the values cast as strings
    void Start()
    {        
        userScore = PlayerPrefs.GetString("playerScore");

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height &&
                        resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
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

    // Record player score and name input to the LeaderboardScript
    public void SubmitButton()
    {
        userName = userText.text;
        LeaderboardScript.Record(userName, userScore);
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
