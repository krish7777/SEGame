using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyWasteStory : MonoBehaviour
{
    // Start is called before the first frame update
    public static int points = 0;
    public AudioSource correctBin;
    public AudioSource wrongBin;
    public AudioSource groundSound;

    WasteStoryController w;
    void Start()
    {
        points = 0;
        w = GameObject.FindObjectOfType<WasteStoryController>().GetComponent<WasteStoryController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (gameObject.name == "Ground" && triggerCollider.tag.EndsWith("Waste"))
        {
            Destroy(triggerCollider.gameObject);
            groundSound.Play();
            points -= 2;
            //w.endGame();
        }
        else
        {
            if (triggerCollider.tag == "GreenWaste")
            {
                if (gameObject.name == "GreenBin")
                {
                    points += 2;
                    correctBin.Play();
                }

                else
                {
                    points -= 1;
                    wrongBin.Play();
                }
                Destroy(triggerCollider.gameObject);

            }
            else if (triggerCollider.tag == "BlueWaste")
            {
                if (gameObject.name == "BlueBin")
                {
                    points += 2;
                    correctBin.Play();
                }
                else
                {
                    points -= 1;
                    wrongBin.Play();
                }
                Destroy(triggerCollider.gameObject);

            }
            else if (triggerCollider.tag == "BlackWaste")
            {
                if (gameObject.name == "BlackBin")
                {
                    points += 2;
                    correctBin.Play();
                }
                else
                {
                    points -= 1;
                    wrongBin.Play();
                }
                Destroy(triggerCollider.gameObject);

            }
        }

        w.updatePoints(points);
        //checkHighscore();



    }

    /*void checkHighscore()
    {
        if (points > PlayerPrefs.GetInt("HighScoreWaste", 0))
        {
            PlayerPrefs.SetInt("HighScoreWaste", points);
            highscoreText.text = points.ToString();
        }
    }
    */
}





