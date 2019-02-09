using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    int tempo = 40;

    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(Vector3.zero, Vector3.up, tempo * Time.deltaTime);
    }
}



