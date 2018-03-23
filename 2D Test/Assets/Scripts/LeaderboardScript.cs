using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardScript : MonoBehaviour
{
    public GameObject leaderboard;

    List<UserScript> userList = new List<UserScript>();    

    private void Start()
    {
        UserScript newUser = new UserScript("MDB", 410, "1:13:56");
        UserScript anotherUser = new UserScript("GPS", 450, "1:18:58");
        UserScript aThirdUser = new UserScript("HJH", 350, "0:59:45");

        userList.Add(newUser);
        userList.Add(anotherUser);
        userList.Add(aThirdUser);

        PrintList();
    }

    private void PrintList()
    {

        for (int i = 0; i < leaderboard.transform.childCount; i++)
        {
            GameObject row = leaderboard.transform.Find("Row" + i).gameObject;
            Debug.Log(row);
        }       
        
    }


    // have gameobject holding name, score and time
    // add it to an array


    // have a function loop through the array and sort it by score, then time if needed

    // find the rows in the editor, and print out the values to their .text properties
}
