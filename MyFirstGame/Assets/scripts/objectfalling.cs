﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectfalling : MonoBehaviour
{
    public float speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate ( Vector3.down * speed * Time.deltaTime);
    }
}
