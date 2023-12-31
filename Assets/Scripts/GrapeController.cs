using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeController : MonoBehaviour
{
    public StarColor starColor; // Color of the collectible star

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.CollectGrape(starColor);
            Destroy(gameObject);
        }
    }
}
