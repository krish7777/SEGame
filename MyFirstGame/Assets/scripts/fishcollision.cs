using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishcollision : MonoBehaviour
{
    public fishmovement movement;

    void OnCollisionEnter ( Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "waste")
        {
            movement.enabled = false;
        }
    }
}
