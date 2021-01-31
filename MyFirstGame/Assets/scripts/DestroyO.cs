using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyO : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other) {
        Destroy (other.gameObject);
    }
}
