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
            Debug.Log("xxxxxxxxxxxxxxxxxxx");
            for (int i = 0; i < mailList.Count; i++)
            {
                Debug.Log("MailList[" + i + "] = " + mailList[i]);
                writer.WriteLine(mailList[i]);
            }
            Debug.Log("xxxxxxxxxxxxxxxxxxx");
        }
    }

    public void AddToList(string input)
    {
        Debug.Log("Input = " + input);
        mailList.Add(input);
        WriteToFile();
    }
}
       