using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    public float fallingSpeed = 5f; // Speed at which the shooting star falls
    public Vector2 diagonalDirection = new Vector2(-1f, -1f); // Diagonal direction of the falling motion
    public Color starColor; // Color of the shooting star

    private GrapeSpawner grapeSpawner; // Reference to the GrapeSpawner object

    private void Start()
    {
        grapeSpawner = FindObjectOfType<GrapeSpawner>();

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

        // Set the color of the shooting star
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = starColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the shooting star has reached the designated area
        if (collision.CompareTag("DesignatedArea"))
        {
            // Stop the falling motion
            StopFalling();

            // Spawn fruit with the matching color
            if (grapeSpawner != null)
            {
                grapeSpawner.SpawnFruit(starColor);
            }
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