using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;  // Array of enemy prefabs
    public int enemyCountMin = 1; // Minimum number of enemies to spawn
    public int enemyCountMax = 5; // Maximum number of enemies to spawn

    public float spawnDelay = 0.5f; // Time delay before spawning enemies
    public List<Transform> spawnPoints; // Spawn points in the room (empty game objects in your room where enemies can spawn)

    private GameObject player; // Reference to the player GameObject
    private bool enemiesSpawned = false; // To prevent multiple spawns

    void Start()
    {
        // Automatically find the player by tag
        player = GameObject.FindWithTag("Player");

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
                    GameObject enemyInstance = Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);

                    // Assign the player to the Field target of the AIDestinationSetter on the enemy
                    AIDestinationSetter aiDestinationSetter = enemyInstance.GetComponent<AIDestinationSetter>();
                    if (aiDestinationSetter != null && player != null)
                    {
                        aiDestinationSetter.target = player.transform; // Assign the player's transform to the target
                    }

                    // Check for the EnemyAI component and assign the player as the target if it exists
                    EnemyAi enemyAI = enemyInstance.GetComponent<EnemyAi>();
                    if (enemyAI != null && player != null)
                    {
                        enemyAI.target = player.transform; // Assuming 'target' is a public GameObject field in EnemyAI
                    }
                }
            }

            enemiesSpawned = true; // Ensure enemies are only spawned once
        }
    }
}


