using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 180.4f;

    public GameObject gameOverTimeUI;
    public GameObject gameOverUI;

    public string newGameScene;

    [SerializeField] TMP_Text countdownText;

    public AudioSource audioSource;
    public AudioClip timer;


    void Start()
    {
        currentTime = startingTime;
        audioSource = GetComponent<AudioSource>();

    }


    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 60.5)
        {
            countdownText.color = Color.red;
        }

        if (currentTime < 0)
        {
            Time.timeScale = 0f;
            gameOverTimeUI.SetActive(true);

        }

        if (gameOverTimeUI.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("SampleScene");
        }


    }

    public void TimerSound()
    {
        audioSource.clip = timer;
        audioSource.Play();

        //if (Time.timeScale = 0f)
        //{
        //Destroy(gameObject);
        //}

    }

}
