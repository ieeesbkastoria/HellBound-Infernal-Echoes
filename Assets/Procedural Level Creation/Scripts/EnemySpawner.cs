using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;  // Array of enemy prefabs
    public int enemyCountMin = 1; // Minimum number of enemies to spawn
    public int enemyCountMax = 5; // Maximum number of enemies to spawn

    public float spawnDelay = 0.5f; // Time delay before spawning enemies
    public List<Transform> spawnPoints; // Spawn points in the room (empty game objects in your room where enemies can spawn)

    private bool enemiesSpawned = false; // To prevent multiple spawns

    void Start()
    {
        // Start spawning enemies after a small delay
        Invoke("SpawnEnemies", spawnDelay);
    }

    void SpawnEnemies()
    {
        if (!enemiesSpawned)
        {
            int enemyCount = Random.Range(enemyCountMin, enemyCountMax + 1); // Determine the number of enemies to spawn

            for (int i = 0; i < enemyCount; i++)
            {
                // Randomly select a spawn point from the list
                if (spawnPoints.Count > 0)
                {
                    Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                    
                    // Randomly select an enemy prefab
                    GameObject enemyToSpawn = enemies[Random.Range(0, enemies.Length)];

                    // Instantiate the enemy at the spawn point
                    Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
                }
            }

            enemiesSpawned = true; // Ensure enemies are only spawned once
        }
    }
}
