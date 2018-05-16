using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Timer : MonoBehaviour
{
    public static float timer;
    private float mins;
    private float secs;
    private string minsString;
    private string secsString;
    public Text timeString;
    public Player_Controller PC;

    private void Start()
    {
        timer = float.Parse(timeString.text);
    }

    // Update is called once per frame
    void Update () {

        if (timer > 0)
        {
            if (!PC.m_endGame)
            {
                timer -= Time.deltaTime;
            }            

            mins = Mathf.Floor(timer / 60);

            if (mins < 10)
            {
                minsString = "0" + mins.ToString();
            }

            else
            {
                minsString = mins.ToString();
            }

            secs = Mathf.RoundToInt(timer % 60);

            if (secs < 10)
            {
                secsString = "0" + secs.ToString();
            }

            else
            {
                secsString = secs.ToString();
            }

            timeString.text = minsString + ":" + secsString;            
        }
        else
        {
            timeString.text = "00:00";
            PC.TestForDeath();
        }

    }
}
