using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct EnemyType
{
    public GameObject prefab;
    public float spawnRate; // Time between spawns
}

public class EnemySpawner : MonoBehaviour
{
    public EnemyType[] enemies; // Assign enemy prefabs & rates in Inspector
    public Transform player;
    public float minSpawnDistance = 5f; // Minimum distance from player
    public float maxSpawnDistance = 10f; // Maximum spawn distance from player
    public int maxAttempts = 10; // Max attempts to find valid spawn position
    public float enemyCollisionRadius = 1f; // Radius to check for overlapping
    public LayerMask enemyLayer; // Layer for enemy overlap checking

    private Camera mainCamera;
    private Vector2 screenBounds;

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        List<float> spawnTimers = new List<float>(new float[enemies.Length]);

        while (true)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                spawnTimers[i] -= Time.deltaTime;
                if (spawnTimers[i] <= 0)
                {
                    SpawnEnemy(enemies[i]);
                    spawnTimers[i] = enemies[i].spawnRate; // Reset spawn timer
                }
            }
            yield return null;
        }
    }

    private void SpawnEnemy(EnemyType enemy)
    {
        Vector2 spawnPosition;
        int attempts = 0;

        do
        {
            spawnPosition = GetSpawnPosition();
            attempts++;
        }
        while (Physics2D.OverlapCircle(spawnPosition, enemyCollisionRadius, enemyLayer) && attempts < maxAttempts);

        if (attempts < maxAttempts)
        {
            Instantiate(enemy.prefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 playerPos = player.position;
        float spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        Vector2 spawnPos = playerPos + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnDistance;

        return spawnPos;
    }
}
