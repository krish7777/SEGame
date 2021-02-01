using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyControl : MonoBehaviour
{
    //private Spawner s;
    public static int difficulty=0;
    // Start is called before the first frame update
    void Start()
    {
        difficulty = 0;
       // s = GameObject.Find("FishGameController").GetComponent<Spawner>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    public void handleDropdown(int val)
    {

        difficulty = val;
        
    }
}
