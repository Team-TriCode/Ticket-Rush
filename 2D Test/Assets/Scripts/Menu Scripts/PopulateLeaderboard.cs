using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateLeaderboard : MonoBehaviour
{
    private GameObject lbTable;

    private void Start()
    {
        lbTable = this.gameObject;
        string playerScore = PlayerPrefs.GetString("playerScore");
        Debug.Log(playerScore);

        for (int i = 1; i < lbTable.transform.childCount; i++)
        {
            GameObject row = lbTable.transform.Find("Row" + i).gameObject;
            //Debug.Log(row);

            for (int j = 0; j < row.transform.childCount; j++)
            {
                string objectTag = row.transform.GetChild(j).tag;
                //Debug.Log(objectTag);
                switch (objectTag)
                {
                    case "rowItemPlace":
                        break;
                    case "rowItemName":
                        break;
                    case "rowItemScore":                        
                        break;
                    case "rowItemTime":
                        break;
                    default:
                        Debug.Log("lol");
                        break;
                }
            }
        }       

        // Need to access Text values of each item
        // Access index and parameters of leaderboard list
                

    }
}
