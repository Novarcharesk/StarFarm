using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public StarColor starColor; // Color of the collectible star

    public SoundManager soundManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Collect(starColor);
            Destroy(gameObject);
            soundManager.CollectStarSound();
        }
    }
}