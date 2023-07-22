using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 90f;

    public TMP_Text countdownText;
    public TMP_Text gameOverText;
    public GameObject gameOverUI;

    private string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime < 0)
        {
            Debug.Log("GameOver!");
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
            gameOverText.gameObject.SetActive(true);
        }

        if (gameOverUI.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(currentSceneName);
        }

        if (gameOverUI.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}