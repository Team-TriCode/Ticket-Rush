using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level_Complete : MonoBehaviour
{
    public Transform winText;
    public Text scoreVal;
    public Text timeVal;
    public Player_Controller pc;
    public ParticleSystem confetti;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowComplete();
        confetti.Play();
        Invoke("PlayerWin", 4.0f);
        pc.m_endGame = true;
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
        // Splitting time val around the colon to get minutes and seconds
        string[] minsSeconds = timeVal.text.Split(':');

        // Converting minutes to seconds to get total seconds
        int minutes = Convert.ToInt32(minsSeconds[0]) * 60;
        int seconds = Convert.ToInt32(minsSeconds[1]) + minutes;

        // Editing scoreVal to get just the number value
        string stringScore = scoreVal.text.Replace("Score: ", "");

        // Converting the edited scoreVal to an int and adding additional score
        int editedScore = Convert.ToInt32(stringScore) + seconds;
        string finalScore = Convert.ToString(editedScore);

        PlayerPrefs.SetString("playerScore", finalScore);
        PlayerPrefs.SetString("playerTime", timeVal.text);
        SceneManager.LoadScene("LevelComplete");
    }
}
