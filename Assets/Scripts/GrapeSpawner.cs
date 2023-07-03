using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeSpawner : MonoBehaviour
{
    public GameObject prefab; // Single prefab to spawn
    public Transform spawnPoint; // Position to spawn the prefab

    public void SpawnPrefab()
    {
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void GrowGrape()
    {
        SpawnPrefab();
    }
}