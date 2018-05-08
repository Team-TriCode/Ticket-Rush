using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitScript : MonoBehaviour
{
    public Text userText;
    private string userName;

    private string userScore;
    private string userTime;

    private void Start()
    {
        userScore = PlayerPrefs.GetString("playerScore");
        userTime = PlayerPrefs.GetString("playerTime");
        Debug.Log("User Score = " + userScore);
        Debug.Log("User Time = " + userTime);
    }

    // Record player score and name input to the LeaderboardScript
    public void SubmitButton()
    {
        userName = userText.text;
        LeaderboardScript.Record(userName, userScore, userTime);
        SceneManager.LoadScene("Leaderboard");
    }
}
