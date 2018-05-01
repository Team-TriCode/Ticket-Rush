using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour {

    public static float timer = 0;
    private float mins;
    private float secs;
    private string minsString;
    private string secsString;
    public Text timeString;
    public Player_Controller pc;

    // Update is called once per frame
    void Update () {

        if (pc.m_endGame == false)
        {
            timer += Time.deltaTime;

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
        
    }
}
