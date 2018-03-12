using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas SettingsCanvas;
    public Text toggleFullScreen;

    private void Awake()
    {
        SettingsCanvas.enabled = false;
    }

    public void OptionsOn()
    {
        SettingsCanvas.enabled = true;
        MainCanvas.enabled = false;
    }

    public void BackOn()
    {
        SettingsCanvas.enabled = false;
        MainCanvas.enabled = true;
    }

    public void LoadOn()
    {
        Application.LoadLevel(1);
    } 

    public void Quit()
    {
        Application.Quit();
    }

    public void setFullScreen()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
            toggleFullScreen.enabled = false;
        }
        else
        {
            Screen.fullScreen = true;
            toggleFullScreen.enabled = false;
        }
    }

    public void setQualityLow()
    {
        int qualityLevel = QualitySettings.GetQualityLevel();
        print(qualityLevel);

        for (int i = 0; i < QualitySettings.names.Length; i++)
        {
            QualitySettings.SetQualityLevel(i, true);
        }
        
    }
}
