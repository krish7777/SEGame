using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WasteMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject infoMenu;
    public GameObject controlsMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startWasteGame()
    {
        SceneManager.LoadScene(5);
    }

    public void exitWasteGame()
    {
        SceneManager.LoadScene(0);

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
}
