using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateLeaderboard : MonoBehaviour
{
    // The whole leadeboard table
    private GameObject lbTable;

    private void Awake()
    {
        lbTable = this.gameObject;
    }

    private void Start()
    {
        LeaderboardScript.GetEntries();
        string tempText;

        for (int i = 1; i <= LeaderboardScript.EntryCount; i++) // Looping through all lbTable children
        {
            GameObject row = lbTable.transform.Find("Row" + i).gameObject; // Finding all the 'Row' gameobjects

            for (int j = 0; j < row.transform.childCount; j++) // Looping through all the row children
            {
                string objectTag = row.transform.GetChild(j).tag; // Finding the tag of the current child
                
                switch (objectTag)
                {
                    case "rowItemPlace":
                        tempText = (i).ToString();
                        row.transform.GetChild(j).GetComponentInChildren<Text>().text = tempText;
                        break;
                    case "rowItemName":
                        tempText = LeaderboardScript.GetEntry(i -1).name;
                        row.transform.GetChild(j).GetComponentInChildren<Text>().text = tempText;
                        break;
                    case "rowItemScore":
                        tempText = LeaderboardScript.GetEntry(i -1).score;
                        tempText = tempText.Replace("Score: ", "");
                        row.transform.GetChild(j).GetComponentInChildren<Text>().text = tempText;                            
                        break;
                    case "rowItemTime":
                        tempText = LeaderboardScript.GetEntry(i -1).time;
                        row.transform.GetChild(j).GetComponentInChildren<Text>().text = tempText;
                        break;
                    default:
                        Debug.Log("lol");
                        break;
                }
            }
        }  
    }

    // Clears all text in leaderboard
    public void ClearAll()
    {
        for (int i = 1; i <= LeaderboardScript.EntryCount; i++) // Looping through all lbTable children
        {
            GameObject row = lbTable.transform.Find("Row" + i).gameObject; // Finding all the 'Row' gameobjects

            for (int j = 0; j < row.transform.childCount; j++) // Looping through all the row children
            {
                row.transform.GetChild(j).GetComponentInChildren<Text>().text = "";                
            }
        }

        LeaderboardScript.ClearScores();
    }
}
