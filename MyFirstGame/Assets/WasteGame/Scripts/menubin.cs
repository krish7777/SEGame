using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menubin : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;


    public void back () {
        s2.SetActive(false);
        s1.SetActive(true);
    }

    public void options () {
        s1.SetActive(false);
        s2.SetActive(true);
    }
}
