using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EmailScript : MonoBehaviour
{
    private List<string> mailList = new List<string>();   

    private void WriteToFile()
    {
        string path = "email_list.txt";

        using (StreamWriter writer = new StreamWriter(path, true))
        {
            for (int i = 0; i < mailList.Count; i++)
            {
                writer.WriteLine(mailList[i]);
            }
        }
    }

    public void AddToList(string input)
    {
        mailList.Add(input);
        WriteToFile();
    }
}
       