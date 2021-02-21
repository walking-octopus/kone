using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    void Update () {
        if (Input.anyKey)
        {
            Application.Quit();
        }
    }
}
