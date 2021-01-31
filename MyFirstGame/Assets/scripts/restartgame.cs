using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartgame : MonoBehaviour
{
    public void restart () {
        Application.LoadLevel (Application.loadedLevel);
    }
}
