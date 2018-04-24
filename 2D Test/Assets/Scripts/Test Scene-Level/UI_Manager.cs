using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private int m_score;
    private GameObject currentScore;
    private Text m_scoreText;

    private void Awake()
    {
        m_score = 0;
    }

    public void AddScore(int score)
    {
        m_score += score;
    }
    private void Update()
    {
        currentScore = GameObject.FindGameObjectWithTag("Score");
        m_scoreText = currentScore.GetComponent<Text>();
        m_scoreText.text = "Score: " + m_score.ToString();
    }
}
