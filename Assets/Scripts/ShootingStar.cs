using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingStar : MonoBehaviour
{
    public float fallingSpeed = 5f;
    public Vector2 diagonalDirection = new Vector2(-1f, -1f);
    public StarColor starColor = StarColor.Red;

    private GrapeSpawner grapeSpawner;

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

    private StarColor GetStarColorFromColor(Color color)
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
        return starColor;
    }
}