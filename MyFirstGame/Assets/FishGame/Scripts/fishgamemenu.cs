using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishgamemenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject infoMenu;
    public GameObject controlsMenu;
    public GameObject difficultyMenu;



    // Start is called before the first frame update
    public void play () {
        SceneManager.LoadScene(3);
        //SceneManager.LoadScene(2);
    }
    

    // Update is called once per frame
    public void quit () {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(2);
    }

    public void openSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void closeSettings()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void openInfo()
    {
        settingsMenu.SetActive(false);
        infoMenu.SetActive(true);
    }

    public void closeInfo()
    {
        settingsMenu.SetActive(true);
        infoMenu.SetActive(false);
    }

    public void openControls()
    {
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void closeControls()
    {
        settingsMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void openDifficulty()
    {
        settingsMenu.SetActive(false);
        difficultyMenu.SetActive(true);
    }

    public void closeDifficullty()
    {
        settingsMenu.SetActive(true);
        difficultyMenu.SetActive(false);
    }


}
