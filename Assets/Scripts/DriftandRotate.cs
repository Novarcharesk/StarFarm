using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftandRotate : MonoBehaviour
{
    public Vector3 driftDirection = Vector3.right;  // Direction of drift
    public float driftSpeed = 1f;                   // Speed of drift
    public float rotationSpeed = 20f;               // Speed of rotation

    private void Update()
    {
        // Drift the object
        transform.Translate(driftDirection * driftSpeed * Time.deltaTime);

        // Rotate the object on its local axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}   