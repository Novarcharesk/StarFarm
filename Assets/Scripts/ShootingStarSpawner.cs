using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarSpawner : MonoBehaviour
{
    public GameObject[] shootingStarPrefabs; // Array of shooting star variants
    public float spawnInterval = 2f;
    public float spawnRangeMin = -10f;
    public float spawnRangeMax = 10f;

    private void Start()
    {
        // Start the coroutine to spawn shooting stars
        StartCoroutine(SpawnShootingStars());
    }

    private System.Collections.IEnumerator SpawnShootingStars()
    {
        while (true)
        {
            // Wait for the spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Generate a random index within the shooting star variants array
            int randomIndex = Random.Range(0, shootingStarPrefabs.Length);

            // Get the randomly selected shooting star prefab
            GameObject randomPrefab = shootingStarPrefabs[randomIndex];

            // Generate a random position within the spawn range
            float randomX = Random.Range(spawnRangeMin, spawnRangeMax);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            // Instantiate the randomly selected shooting star prefab at the random position
            Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        }
    }
}