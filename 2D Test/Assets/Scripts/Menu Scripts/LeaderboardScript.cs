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

        public ScoreEntry(string name, string score)
        {
            this.name = name;
            this.score = score;
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
        }
    }    

    public static void ClearScores()
    {
        Entries.Clear();
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < EntryCount; i++)
        {
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].name", "");
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].score", "");
        }        
    }

    // Records a new entry
    public static void Record(string name, string score)
    {
        Entries.Add(new ScoreEntry(name, score));
        SortScores();
        Entries.RemoveAt(Entries.Count - 1);
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
            Debug.Log("entryName = " + entryName + "\nentryScore = " + entryScore);
        }
        Debug.Log("=============");

        return temp;
    }
}
