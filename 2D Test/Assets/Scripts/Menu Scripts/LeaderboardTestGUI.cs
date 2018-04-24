using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardTestGUI : MonoBehaviour
{
    private string nameInput = "";
    private string scoreInput = "0";

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        for (int i = 0; i < LeaderboardScript.EntryCount; i++)
        {
            var entry = LeaderboardScript.GetEntry(i);
            GUILayout.Label("Name: " + entry.name + ", Score: " + entry.score);
        }

        GUILayout.Space(10);

        nameInput = GUILayout.TextField(nameInput);
        scoreInput = GUILayout.TextField(scoreInput);

        if (GUILayout.Button("Record"))
        {
            int score;
            int.TryParse(scoreInput, out score);

            LeaderboardScript.Record(nameInput, score);

            nameInput = "";
            scoreInput = "0";
        }

        GUILayout.EndArea();
    }
}
