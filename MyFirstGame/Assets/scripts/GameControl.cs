using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // private Camera cam;
    public GameObject[] fallingBlockPrefabs;

    public GameObject EndText;
    public GameObject EndButton;

    public GameObject menu;

    private float maxWidth;

    public float remainingTime;

    public Text timerText;

    public BinController binController;

    Vector2 screenHalfSizeWorldUnits;

    private bool playing;
    

    
    // Start is called before the first frame update
    void Start()
    {
        // cam = GetComponent<Camera>().main;
        var cam  = Camera.main;
        playing = false ; 
        Vector3 upperCorner = new Vector3 (Screen.width , Screen.height , 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
        float paperWidth = fallingBlockPrefabs[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - paperWidth;

        screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

        PrintText ();
    }

    void Update () {
        if(playing)
        {
        remainingTime -=Time.deltaTime;
        if ( remainingTime < 0 )
            remainingTime = 0;
        
        PrintText ();
        }
    }

    public void startgame () {
        menu.SetActive(false);
        binController.togglecontrol (true);
        StartCoroutine (Spawn());

    }

    IEnumerator Spawn ()
    {
        yield return new WaitForSeconds (1.0f);
        playing = true;
        while (remainingTime > 0)
        {
            GameObject fallingBlockPrefab = fallingBlockPrefabs[Random.Range(0,fallingBlockPrefabs.Length)];
            Vector3 spawnPosition = new Vector3 (
            Random.Range (-maxWidth , maxWidth),
            screenHalfSizeWorldUnits.y+2.0f,
            0.0f
        );
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate (fallingBlockPrefab , spawnPosition , spawnRotation);
        yield return new WaitForSeconds (Random.Range (0.5f , 1.0f));
        }
        yield return new WaitForSeconds (1.0f);
        EndText.SetActive (true);
        yield return new WaitForSeconds (2.0f);
        EndButton.SetActive (true);
    }

    void PrintText () {
        timerText.text = "Time Left: " + Mathf.RoundToInt (remainingTime);
    }

    public void quit () {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(2);
    }
}
