using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public SoundManager soundManager;

    public GameObject shopCanvas;
    public Button leaveButton;

    private bool playerInsideTrigger = false;
    private bool isGamePaused = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            soundManager.StoreJingleSound();
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
            shopCanvas.SetActive(true);
            soundManager.StoreJingleSound();

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

    public void CloseShop()
    {
        shopCanvas.SetActive(false);
        ResumeGame();
    }

    public void OnLeaveButtonClicked()
    {
        CloseShop();
    }
}