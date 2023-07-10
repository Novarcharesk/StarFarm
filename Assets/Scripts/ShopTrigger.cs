using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public Canvas shopCanvas;
    public Button resumeButton;
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
            shopCanvas.enabled = false;
            if (isGamePaused)
            {
                ResumeGame();
            }
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

    public void OnResumeButtonClicked()
    {
        shopCanvas.enabled = false;
        ResumeGame();
    }

    public void OnLeaveButtonClicked()
    {
        shopCanvas.enabled = false;
        ResumeGame();
        // Additional logic for leaving the shop
    }
}