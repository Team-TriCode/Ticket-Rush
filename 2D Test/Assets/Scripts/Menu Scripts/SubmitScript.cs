using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitScript : MonoBehaviour
{
    public Text userText;
    public Text mailText;

    private string userName;
    private string userEmail;
    private string userScore;
    private string userTime;

    public EmailScript emailScript;

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
        userEmail = mailText.text;
        Debug.Log("UserEmail = " + userEmail);
        LeaderboardScript.Record(userName, userScore, userTime);
        emailScript.AddToList(userEmail);
        SceneManager.LoadScene("Leaderboard");
    }
}
