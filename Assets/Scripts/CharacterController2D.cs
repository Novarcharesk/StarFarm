using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public int starCount = 0;
    public GameObject heldStar; // Reference to the star held by the player

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (heldStar != null)
            {
                // Check if there's a GrapeSpawner nearby
                Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
                foreach (Collider2D collider in nearbyColliders)
                {
                    GrapeSpawner grapeSpawner = collider.GetComponent<GrapeSpawner>();
                    if (grapeSpawner != null)
                    {
                        // Plant the held star
                        grapeSpawner.GrowGrape();
                        Destroy(heldStar);
                        heldStar = null; // Clear the held star reference
                        break;
                    }
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible") && heldStar == null)
        {
            Collect(collision.gameObject);
        }
    }

    public void Collect(GameObject star)
    {
        // Increase star count
        starCount++;

        // Set the held star to the collected star
        heldStar = star;

        // Perform any other actions or updates based on collecting the star
        Debug.Log("Star collected! Count: " + starCount);
    }
}
