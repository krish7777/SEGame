using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WasteStoryController : MonoBehaviour
{
    public Vector2 screenHalfUnit;
    public float secondBetweenSpawns = 2;
    public GameObject[] fallingWastePrefabs;

    public GameObject blackBin;
    public GameObject greenBin;
    public GameObject blueBin;



    public GameObject storyEndMenu;
    public GameObject pauseMenu;

    public GameObject pauseButton;

    public float remainingTime = 20;

    public Text timerText;
    public Text pointsText;

    private bool playing;

    private int currentLinearDrag = 10;

    public float[] positions;

    float nextSpawnTime;

    void Start()
    {
        Time.timeScale = 1;
        screenHalfUnit = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        playing = true;
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize * 2;

        float cubeWidth = (screenWidth - 0.6f) / 5f;

        greenBin.transform.position = new Vector2(0, -3.8f);
        blueBin.transform.position = new Vector2((2 * cubeWidth) + 0.2f, -3.8f);
        blackBin.transform.position = new Vector2(-((2 * cubeWidth) + 0.2f), -3.8f);

        positions = new float[] { 0, cubeWidth + 0.1f, (2 * cubeWidth) + 0.2f, -(cubeWidth + 0.1f), -(2 * cubeWidth + 0.2f) };
        remainingTime = 2;
        /* positions = new float[] { 0, 1.1f, 2.2f, -1.1f, -2.2f };*/

    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0)
            {
                endGame();
                /*
                remainingTime = 10;
                currentLinearDrag -= 1;
                if (currentLinearDrag <= 1)
                    currentLinearDrag = 1;

                */

            }

            printTime();

            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime = Time.time + secondBetweenSpawns;
                Vector3 spawnPosition = new Vector3(positions[(int)Random.Range(0, 4.99f)], Camera.main.orthographicSize + 0.5f, 0.1f);
                GameObject fallingWastePrefab = fallingWastePrefabs[Random.Range(0, fallingWastePrefabs.Length)];
                fallingWastePrefab.GetComponent<Rigidbody2D>().drag = currentLinearDrag;
                Instantiate(fallingWastePrefab, spawnPosition, Quaternion.identity);
            }
        }


    }

    public void endGame()
    {
        remainingTime = 0;
        playing = false;
        storyEndMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void updatePoints(int points)
    {
        pointsText.text = points.ToString();

    }
    void printTime()
    {   
        timerText.text = Mathf.RoundToInt(remainingTime).ToString();
    }
    

    public void quit()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(2);
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        playing = false;
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        playing = true;
        pauseButton.SetActive(true);
        Time.timeScale = 1;

    }

    public void restartWasteGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void continueToFishStory()
    {
        //Load Scene
        SceneManager.LoadScene(1);
    }
}
