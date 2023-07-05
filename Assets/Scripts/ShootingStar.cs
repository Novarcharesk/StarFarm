using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    public float fallingSpeed = 5f; // Speed at which the shooting star falls
    public Vector2 diagonalDirection = new Vector2(-1f, -1f); // Diagonal direction of the falling motion

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
                // Get the color of the shooting star prefab
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Color starColor = spriteRenderer.color;
                    StarColor convertedColor = GetStarColorFromColor(starColor); // Convert the Color to StarColor
                    grapeSpawner.SpawnFruit(convertedColor); // Pass the converted StarColor
                }
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

    private StarColor GetStarColorFromColor(Color color) // Helper method to convert Color to StarColor
    {
        if (color == Color.red)
            return StarColor.Red;
        else if (color == Color.green)
            return StarColor.Green;
        else if (color == Color.blue)
            return StarColor.Blue;
        else if (color == Color.yellow)
            return StarColor.Yellow;
        else
            return StarColor.Red;
    }

    public StarColor GetStarColor()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            Color starColor = spriteRenderer.color;
            StarColor convertedColor = GetStarColorFromColor(starColor);
            return convertedColor;
        }
        return StarColor.Red; // Default color if no valid color found
    }
}