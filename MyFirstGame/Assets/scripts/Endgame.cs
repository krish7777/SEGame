using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    public GameObject EndText;
    public GameObject EndButton;
    public GameObject WasteFalling;

    void OnTriggerEnter2D (Collider2D other) {
        
        if(other.gameObject.tag == "paper")
        {
        EndText.SetActive (true);
        
        EndButton.SetActive (true);

        WasteFalling.SetActive (false);
        }
    }
}
