using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserScript : MonoBehaviour
{
    public string userName { get; set; }
    public int userScore { get; set; }
    public string userTime { get; set; }

    public UserScript() { }

    public UserScript(string name, int score, string time)
    {
        userName = name;
        userScore = score;
        userTime = time;
    }
}
