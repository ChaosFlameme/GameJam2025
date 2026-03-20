using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation
    void Update()
    {
        // Rotate the object around its Z-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
