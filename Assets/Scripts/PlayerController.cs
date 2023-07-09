using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum StarColor
{
    Red,
    Green,
    Blue,
    Yellow
}


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public TextMeshProUGUI[] starCountTexts;
    public GameObject[] grapesToSpawn;
    public Transform[] locationsToSpawn;
    public TextMeshProUGUI[] grapeCountTexts;
    private Rigidbody2D rb;
    private int[] starCount;
    private int[] grapeCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        starCount = new int[System.Enum.GetValues(typeof(StarColor)).Length];
        grapeCount = new int[System.Enum.GetValues(typeof(StarColor)).Length];
        UpdateStarCountUI();
        UpdateGrapeCountUI();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Star"))
        //{
        //    ShootingStar shootingStar = collision.GetComponent<ShootingStar>();
        //    if (shootingStar != null)
        //    {
        //        StarColor collectedColor = shootingStar.GetStarColor();
        //        Collect(collectedColor);
        //        Destroy(collision.gameObject);
        //    }
        //}

        if (collision.CompareTag("Grow"))
        {
            if (HasInventoryItem(StarColor.Red))
            {
                Instantiate(grapesToSpawn[0], locationsToSpawn[0].position, Quaternion.identity);
                ResetStarCount(StarColor.Red);
                UpdateStarCountUI();
            }
            if (HasInventoryItem(StarColor.Green))
            {
                Instantiate(grapesToSpawn[1], locationsToSpawn[1].position, Quaternion.identity);
                ResetStarCount(StarColor.Green);
                UpdateStarCountUI();
            }
            if (HasInventoryItem(StarColor.Blue))
            {
                Instantiate(grapesToSpawn[2], locationsToSpawn[2].position, Quaternion.identity);
                ResetStarCount(StarColor.Blue);
                UpdateStarCountUI();
            }
            if (HasInventoryItem(StarColor.Yellow))
            {
                Instantiate(grapesToSpawn[3], locationsToSpawn[3].position, Quaternion.identity);
                ResetStarCount(StarColor.Yellow);
                UpdateStarCountUI();
            }
        }
    }

    public void Collect(StarColor color)
    {
        Debug.Log("Collected " + color.ToString() + " star");
        IncreaseStarCount(color);
        UpdateStarCountUI();
    }

    public void CollectGrape(StarColor color)
    {
        Debug.Log("Collected " + color.ToString() + " grape");
        IncreaseGrapeCount(color);
        UpdateGrapeCountUI();
    }

    private void IncreaseStarCount(StarColor color)
    {
        int colorIndex = (int)color;
        if (colorIndex >= 0 && colorIndex < starCount.Length)
        {
            starCount[colorIndex]++;
        }
    }

    private void IncreaseGrapeCount(StarColor color)
    {
        int colorIndex = (int)color;
        if (colorIndex >= 0 && colorIndex < grapeCount.Length)
        {
            grapeCount[colorIndex]++;
        }
    }

    private void ResetStarCount(StarColor color)
    {
        int colorIndex = (int)color;
        if (colorIndex >= 0 && colorIndex < starCount.Length)
        {
            starCount[colorIndex] = 0;
        }
    }

    private void UpdateStarCountUI()
    {
        for (int i = 0; i < starCountTexts.Length; i++)
        {
            if (i >= 0 && i < starCount.Length)
            {
                starCountTexts[i].text = "= " + starCount[i].ToString();
            }
        }
    }

    private void UpdateGrapeCountUI()
    {
        for (int i = 0; i < grapeCountTexts.Length; i++)
        {
            if (i >= 0 && i < grapeCount.Length)
            {
                grapeCountTexts[i].text = "= " + grapeCount[i].ToString();
            }
        }
    }

    public bool HasInventoryItem(StarColor color)
    {
        int colorIndex = (int)color;
        if (colorIndex >= 0 && colorIndex < starCount.Length)
        {
            return starCount[colorIndex] > 0;
        }
        return false;
    }
}