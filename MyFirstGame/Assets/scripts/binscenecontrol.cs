using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class binscenecontrol : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    public void gstory1 () {
        s2.SetActive(false);
        s1.SetActive(true);
    }

    public void cstory2 () {
        s1.SetActive(false);
        s2.SetActive(true);
    }

    public void gstory2 () {
        s3.SetActive(false);
        s2.SetActive(true);
    }

    public void cstory3 () {
        
        s2.SetActive(false);
        s3.SetActive(true);
    }

    public void gstory3()
    {
        s4.SetActive(false);
        s3.SetActive(true);
    }

    public void cstory4()
    {

        s3.SetActive(false);
        s4.SetActive(true);
    }

    public void next () {
        SceneManager.LoadScene(8);
        //SceneManager.LoadScene(2);
    }

    public void goback () {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(2);
    }
}
