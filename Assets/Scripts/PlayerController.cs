using System.Collections;
using System.Collections.Generic;
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
    public Text[] starCountTexts;
    private Rigidbody2D rb;
    private int[] starCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        starCount = new int[System.Enum.GetValues(typeof(StarColor)).Length];
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
        if (collision.CompareTag("Star"))
        {
            ShootingStar shootingStar = collision.GetComponent<ShootingStar>();
            if (shootingStar != null)
            {
                StarColor collectedColor = shootingStar.GetStarColor();
                Collect(collectedColor);
                Destroy(collision.gameObject);
            }
        }
    }

    public void Collect(StarColor color)
    {
        IncreaseStarCount(color);
        UpdateStarCountUI();
    }

    private void IncreaseStarCount(StarColor color)
    {
        int colorIndex = (int)color;
        if (colorIndex >= 0 && colorIndex < starCount.Length)
        {
            starCount[colorIndex]++;
        }
    }

    private void UpdateStarCountUI()
    {
        for (int i = 0; i < starCountTexts.Length; i++)
        {
            if (i >= 0 && i < starCount.Length)
            {
                starCountTexts[i].text = starCount[i].ToString();
            }
        }
    }
}