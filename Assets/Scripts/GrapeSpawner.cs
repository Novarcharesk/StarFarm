using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrapeSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs; // Array of fruit prefabs in matching order of colors
    public Transform spawnPoint; // Position to spawn the fruit

    public void SpawnFruit(StarColor fruitColor)
    {
        int colorIndex = (int)fruitColor;
        if (colorIndex != -1 && colorIndex < fruitPrefabs.Length)
        {
            GameObject fruitPrefab = fruitPrefabs[colorIndex];
            GameObject fruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);

            // Set the color of the spawned fruit to match the color of the star
            SpriteRenderer fruitRenderer = fruit.GetComponent<SpriteRenderer>();
            if (fruitRenderer != null)
            {
                fruitRenderer.color = GetColorFromStarColor(fruitColor);
            }

            // Set any additional properties or logic for the spawned fruit
        }
    }

    private int GetColorIndex(StarColor color)
    {
        for (int i = 0; i < fruitPrefabs.Length; i++)
        {
            SpriteRenderer spriteRenderer = fruitPrefabs[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && spriteRenderer.color == GetColorFromStarColor(color))
            {
                return i;
            }
        }
        return -1;
    }

    private Color GetColorFromStarColor(StarColor starColor)
    {
        switch (starColor)
        {
            case StarColor.Red:
                return Color.red;
            case StarColor.Green:
                return Color.green;
            case StarColor.Blue:
                return Color.blue;
            case StarColor.Yellow:
                return Color.yellow;
            default:
                return Color.white;
        }
    }
}