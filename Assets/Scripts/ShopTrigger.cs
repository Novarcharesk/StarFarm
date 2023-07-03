using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public Canvas shopCanvas;

    private bool playerInsideTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            shopCanvas.enabled = false;
        }
    }

    private void Update()
    {
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            shopCanvas.enabled = true;
        }
    }
}