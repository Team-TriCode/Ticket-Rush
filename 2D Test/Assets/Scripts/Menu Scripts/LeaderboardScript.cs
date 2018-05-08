using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScript : MonoBehaviour
{
    public const int EntryCount = 6;
    private const string PlayerPrefsBaseKey = "leaderboard";

    // Score custom variable struct
    public struct ScoreEntry
    {
        public string name;
        public string score;
        public string time;

        public ScoreEntry(string name, string score, string time)
        {
            this.name = name;
            this.score = score;
            this.time = time;
        }
    }    

    // Entry list
    private static List<ScoreEntry> s_Entries;

    // Creates new s_Entries list if none exists
    private static List<ScoreEntry> Entries
    {
        get
        {
            if (s_Entries == null)
            {
                s_Entries = new List<ScoreEntry>();
                LoadScores();
            }
            return s_Entries;
        }
    }           

    // Load blank scores
    private static void LoadScores()
    {
        s_Entries.Clear();

        for (int i = 0; i < EntryCount; i++)
        {
            ScoreEntry entry;
            entry.name = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].name", "");
            entry.score = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].score", "");
            entry.time = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].time", "");
            s_Entries.Add(entry);
        }

        SortScores();
    }

    // Sorts scores
    private static void SortScores()
    {
        s_Entries.Sort((a, b) => b.score.CompareTo(a.score));
    }

    // Save current scores
    private static void SaveScores()
    {
        for (int i = 0; i < EntryCount; i++)
        {
            var entry = s_Entries[i];
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].name", entry.name);
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].score", entry.score);
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].time", entry.time);
        }
    }    

    public static void ClearScores()
    {
        for (int i = 0; i < EntryCount; i++)
        {
            Entries[i] = new ScoreEntry("", "", "");

            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].name", "");
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].score", "");
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].time", "");
        }        
    }

    // Records a new entry
    public static void Record(string name, string score, string time)
    {
        Entries.Add(new ScoreEntry(name, score, time));
        SortScores();
        if (Entries != null)
        {
            Entries.RemoveAt(Entries.Count - 1);
        }        
        SaveScores();
    }

    // Returns entry from given index
    public static ScoreEntry GetEntry(int index)
    {
        return Entries[index];
    }

    // Return all entries
    public static ScoreEntry GetEntries()
    {
        ScoreEntry temp = Entries[0];

        Debug.Log("=============");
        for (int i = 0; i < LeaderboardScript.EntryCount; i++)
        {
            string entryName = LeaderboardScript.GetEntry(i).name;
            string entryScore = LeaderboardScript.GetEntry(i).score;
            string entryTime = LeaderboardScript.GetEntry(i).time;
            Debug.Log("entryName = " + entryName + "\nentryScore = " + entryScore + "\nentryTime = " + entryTime);
            Debug.Log("entryTime = " + entryTime);
        }
        Debug.Log("=============");

        return temp;
    }
}
