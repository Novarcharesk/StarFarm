using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    public float fallingSpeed = 5f; // Speed at which the shooting star falls
    public Vector2 diagonalDirection = new Vector2(-1f, -1f); // Diagonal direction of the falling motion

    private void Start()
    {
        // Start the falling motion
        StartFalling();
    }

    private void StartFalling()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Calculate the initial velocity using the diagonal direction and falling speed
        Vector2 initialVelocity = diagonalDirection.normalized * fallingSpeed;

        // Apply the initial velocity to the shooting star
        rb.velocity = initialVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the shooting star has reached the designated area
        if (collision.CompareTag("DesignatedArea"))
        {
            // Stop the falling motion
            StopFalling();
        }
    }

    private void StopFalling()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Disable the Rigidbody2D component to stop further movement
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
    }
}