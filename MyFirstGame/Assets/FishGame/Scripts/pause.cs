using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;

    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape))
        {   
            
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause() {
        pauseButton.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;        
    }


    public void quit() {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene (2);
    }

    public void quitb() {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene (5);
    }

    public void restartFishGame()
    {
        SceneManager.LoadScene(3);
    }

}
