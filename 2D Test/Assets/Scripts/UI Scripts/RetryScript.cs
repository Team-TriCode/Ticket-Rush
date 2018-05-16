using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    [SerializeField]
    private Image timerImage;
    private float timeToCount = 5;
    private float time;
    [SerializeField]
    private Text countdownText;

    private void Start()
    {
        timerImage = this.GetComponentInChildren<Image>();
        time = timeToCount;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerImage.fillAmount = time / timeToCount;
            countdownText.text = time.ToString("N0");
        }
        if (time <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


}
