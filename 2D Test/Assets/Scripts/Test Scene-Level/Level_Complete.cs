using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level_Complete : MonoBehaviour
{
    public Transform winText;
    public Text scoreVal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowComplete();
        Invoke("PlayerWin", 2.5f);
    }

    private void ShowComplete()
    {
        if (winText.gameObject.activeInHierarchy == false)
        {
            winText.gameObject.SetActive(true);
            Invoke("HideComplete", 2.0f);
        }
    }

    private void HideComplete()
    {
        if (winText.gameObject.activeInHierarchy == true)
        {
            winText.gameObject.SetActive(false);
        }
    }

    private void PlayerWin()
    {
        PlayerPrefs.SetString("playerScore", scoreVal.text);
        SceneManager.LoadScene("LevelComplete");
    }
}
