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
    public void SettingsOn()
    {
        SettingsCanvas.enabled = true;
        MainCanvas.enabled = false;
    }
    public void ReturnOn()
    {
        SettingsCanvas.enabled = false;
        MainCanvas.enabled = true;
    }
    public void loadOn()
    {
        Application.LoadLevel(1);
    } 


}
