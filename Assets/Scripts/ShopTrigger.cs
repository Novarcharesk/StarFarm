using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public Canvas shopCanvas;
    public Button leaveButton;

    private bool playerInsideTrigger = false;
    private bool isGamePaused = false;

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
            CloseShop();
        }
    }

    private void Update()
    {
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            shopCanvas.enabled = true;
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    private void CloseShop()
    {
        shopCanvas.enabled = false;
        ResumeGame();
    }

    public void OnLeaveButtonClicked()
    {
        CloseShop();
        // Additional logic for leaving the shop
    }
}