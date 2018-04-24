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
        public int score;

        public ScoreEntry(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    private void Awake()
    {
        string playerScore = PlayerPrefs.GetString("playerScore");
        Debug.Log(playerScore);
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
            entry.score = PlayerPrefs.GetInt(PlayerPrefsBaseKey + "[" + i + "].score", 0);
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
            PlayerPrefs.SetInt(PlayerPrefsBaseKey + "[" + i + "].score", entry.score);
        }
    }

    // Returns entry from given index
    public static ScoreEntry GetEntry(int index)
    {
        return Entries[index];
    }

    // Records a new entry
    public static void Record(string name, int score)
    {
        Entries.Add(new ScoreEntry(name, score));
        SortScores();
        Entries.RemoveAt(Entries.Count - 1);
        SaveScores();
    }

    //public GameObject leaderboard;

    //List<UserScript> userList = new List<UserScript>();

    //private void Start()
    //{
    //    UserScript newUser = new UserScript("MDB", 410, "1:13:56");
    //    UserScript anotherUser = new UserScript("GPS", 450, "1:18:58");
    //    UserScript aThirdUser = new UserScript("HJH", 350, "0:59:45");

    //    userList.Add(newUser);
    //    userList.Add(anotherUser);
    //    userList.Add(aThirdUser);

    //    PrintList();
    //}

    //private void PrintList()
    //{
    //    for (int i = 0; i < leaderboard.transform.childCount; i++)
    //    {
    //        GameObject row = leaderboard.transform.Find("Row1").gameObject;
    //        GameObject name = row.transform.Find("NameColumn").gameObject;
    //        Text nameText = name.GetComponent<Text>();
    //        nameText.text = "Lol";

    //    }

    //}


    //have gameobject holding name, score and time
    // add it to an array


    // have a function loop through the array and sort it by score, then time if needed

    // find the rows in the editor, and print out the values to their.text properties
}
