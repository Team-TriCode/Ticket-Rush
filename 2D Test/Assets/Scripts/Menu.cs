using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas SettingsCanvas;

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

}
