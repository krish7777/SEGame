using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteMovement : MonoBehaviour
{
    // Update is called once per frame
    private bool isMoving;
    private bool touchStarted = false;
    private Vector2 origPos, targetPos;
    private Vector2 startTouchPos, endTouchPos;
    public float thresholdPos;

    private Vector2 mousePosition;

    private float timeToMove = 0.1f;
    private float diffX;
    private float diffY;

    public float gravityY = -0.16f;
    public float cubeWidth;


    private float screenWidth;


    void Start()
    {
        
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize *2;
       
        cubeWidth = (screenWidth - 0.6f)/ 5f;
        /*transform.localScale = new Vector2(cubeWidth,1);*/
        thresholdPos = 2 * cubeWidth;
        
        

        /*
        cubeWidth = 1;
        thresholdPos = 2;
        */

    }



    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector2.up));
        else if (Input.GetKey(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector2.right));
        else if (Input.GetKey(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector2.down));
        else if (Input.GetKey(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector2.left));

        */





        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !touchStarted)
        {
            startTouchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            diffX = Mathf.Abs(startTouchPos.x - transform.position.x);
            diffY = Mathf.Abs(startTouchPos.y - transform.position.y);
            if (diffX < 0.5 && diffY < 0.5)
            {
                touchStarted = true;
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && touchStarted)
        {
            endTouchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if ((endTouchPos.x < startTouchPos.x) && transform.position.x > -thresholdPos)
                StartCoroutine(MovePlayer(new Vector2(-(cubeWidth + 0.1f), gravityY)));
            if ((endTouchPos.x > startTouchPos.x) && transform.position.x < thresholdPos)
                StartCoroutine(MovePlayer(new Vector2(cubeWidth + 0.1f, gravityY)));
            touchStarted = false;
        }


    }

    private IEnumerator MovePlayer(Vector2 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector2.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }


    void OnMouseDown()
    {
        startTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diffX = Mathf.Abs(startTouchPos.x - transform.position.x);
        diffY = Mathf.Abs(startTouchPos.y - transform.position.y);
        if (diffX < 0.5 && diffY < 0.5)
        {
            touchStarted = true;
        }

    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseUp()
    {
        if (touchStarted)
        {
            endTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if ((endTouchPos.x < startTouchPos.x) && transform.position.x > -thresholdPos)
                StartCoroutine(MovePlayer(new Vector2(-(cubeWidth + 0.1f), gravityY)));
            if ((endTouchPos.x > startTouchPos.x) && transform.position.x < thresholdPos)
                StartCoroutine(MovePlayer(new Vector2(cubeWidth + 0.1f, gravityY)));
            touchStarted = false;
        }
    }
}
