using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishgamemenu : MonoBehaviour
{

    public GameObject menu;
    public GameObject optionsmenu;

    public void openoptions () {
        menu.SetActive(false);
        optionsmenu.SetActive(true);
    }


    public void gobackO () {
        optionsmenu.SetActive(false);
        menu.SetActive(true);
        //SceneManager.LoadScene(2);
    }


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
}
