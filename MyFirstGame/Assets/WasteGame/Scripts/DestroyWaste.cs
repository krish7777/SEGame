using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWaste : MonoBehaviour
{
    // Start is called before the first frame update
    public static int points = 0;

    WasteGameController w;
    void Start()
    {
        points = 0;
        w = GameObject.FindObjectOfType<WasteGameController>().GetComponent<WasteGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(gameObject.name == "Ground" && triggerCollider.tag.EndsWith("Waste"))
        {
            Debug.Log("End Game");
            Destroy(triggerCollider.gameObject);
            w.endGame();
        }
        else
        {
            if (triggerCollider.tag == "GreenWaste")
            {
                if (gameObject.name == "GreenBin")
                    points += 2;
                else
                    points -= 1;
                Destroy(triggerCollider.gameObject);

            }
            else if (triggerCollider.tag == "BlueWaste")
            {
                if (gameObject.name == "BlueBin")
                    points += 2;
                else
                    points -= 1;
                Destroy(triggerCollider.gameObject);

            }
            else if(triggerCollider.tag == "BlackWaste")
            {
                if (gameObject.name == "BlackBin")
                    points += 2;
                else
                    points -= 1;
                Destroy(triggerCollider.gameObject);

            }
        }

        w.updatePoints(points);

        Debug.Log("Score" + points);



    }
}
