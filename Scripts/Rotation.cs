using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation: MonoBehaviour
{
    public Vector3 rotationSpeed; 

    private void Update()
    {
        // Rotate the object according to the specified rotation speed
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}

