using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Sprite forwardSprite;
    public Sprite backwardSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void MoveCharacter()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //transform.Translate(movement * moveSpeed * Time.deltaTime);
        gameObject.GetComponent<Rigidbody2D>().velocity = (movement * moveSpeed * Time.deltaTime);

        // Update sprite based on movement direction
        if (moveVertical > 0) // Moving up
        {
            spriteRenderer.sprite = backwardSprite;
        }
        else // Moving in any other direction
        {
            spriteRenderer.sprite = forwardSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectible collectible = other.GetComponent<Collectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }
    }

    private void Update()
    {
        MoveCharacter();
    }
}