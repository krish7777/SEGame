using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinController : MonoBehaviour
{

    private float maxWidth;
    private bool control;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
        cam  = Camera.main;
        control = false ; 
        Vector3 upperCorner = new Vector3 (Screen.width , Screen.height , 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
        float binWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - binWidth;

    }

    // Update is called once per frame
    void Update()
    {
        if(control) {
            Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
            Vector3 targetPosition = new Vector3 (rawPosition.x , 0.0f , 0.0f);
            float targetWidth = Mathf.Clamp (targetPosition.x , -maxWidth , maxWidth );
            targetPosition = new Vector3 (targetWidth , -5.0f , targetPosition.z);
            GetComponent<Rigidbody2D>().MovePosition (targetPosition);
        }
    }

    public void togglecontrol (bool toggle) {
        control = toggle;
    }
}
