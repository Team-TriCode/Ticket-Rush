using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseCanvas;

    [SerializeField]
    private GameObject optionsMenu;
    [SerializeField]
    private GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start Button"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (pauseCanvas.gameObject.activeInHierarchy == false)
        {
            Time.timeScale = 0;
            pauseCanvas.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(true);
            optionsMenu.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.gameObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
