using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseScript : MonoBehaviour
{
    public GameObject levelComplete;
    public GameObject gameOver;

    private void Start()
    {
        GameObject newObj = GameObject.Find("LevelCompleteText");

        if (newObj.activeInHierarchy == true)
        {
            levelComplete.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            levelComplete.SetActive(false);
            gameOver.SetActive(true);
        }


    }

}
