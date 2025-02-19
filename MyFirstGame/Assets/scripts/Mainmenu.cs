﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject gamemode;
    public GameObject menu;
    public GameObject optionsmenu;

    public void start () {
        menu.SetActive(false);
        gamemode.SetActive(true);
    }

    public void openoptions () {
        menu.SetActive(false);
        optionsmenu.SetActive(true);
    }

     public void goback () {
        gamemode.SetActive(false);
        menu.SetActive(true);
        //SceneManager.LoadScene(2);
    }

     public void playgamescene () {
        SceneManager.LoadScene(6);
        //SceneManager.LoadScene(2);
    }

    public void gobackO () {
        optionsmenu.SetActive(false);
        menu.SetActive(true);
        //SceneManager.LoadScene(2);
    }

    public void playgamefish () {
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(2);
    }

    public void playgamebin () {
        SceneManager.LoadScene(4);
        //SceneManager.LoadScene(2);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void muteAudio()
    {
        AudioListener.volume = 0;
    }

    public void unmuteAudio()
    {
        AudioListener.volume = 1;
    }

    public void handleAudioCheckbox(bool val)
    {
        if (val)
            unmuteAudio();
        else
            muteAudio();
    }

    // public void playgame () {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    //     //SceneManager.LoadScene(2);
    // }

    // public void playgame () {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    //     //SceneManager.LoadScene(2);
    // }

   
}
