using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public void PlayButton()
    {
        EditorSceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
