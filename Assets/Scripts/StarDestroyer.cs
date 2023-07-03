using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is a game object
        if (collision.gameObject.CompareTag("Star"))
        {
            // Destroy the collided game object
            Destroy(collision.gameObject);
        }
    }
}
