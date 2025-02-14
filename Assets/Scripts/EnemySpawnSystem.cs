using UnityEngine;
using System.Collections;

public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField] private float minSpawnDistance = 20.0f;
    [SerializeField] private float maxSpawnDistance = 30.0f;

    [SerializeField] public GameObject[] enemyTable;
    [SerializeField] private GameObject playerRef;
    [SerializeField] private float spawnInterval = 3f;

    public int level = 1;
    public bool bossMode = false;
    private bool isSpawning = true;
    private bool canSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyTable[0], new Vector3(playerRef.transform.position.x, playerRef.transform.position.y + minSpawnDistance, playerRef.transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning && canSpawn)
        {
            StartCoroutine("SpawnEnemy");
        }
    }

    private IEnumerator SpawnEnemy()
    {
        canSpawn = false;

        yield return new WaitForSeconds(spawnInterval);

        int enemyType = Random.Range(0, level);
        GameObject enemy = enemyTable[enemyType];

        // Spawn X
        float spawnDisX = Random.Range(minSpawnDistance, maxSpawnDistance);
        if (Random.Range(0, 2) == 0)
        {
            spawnDisX = -spawnDisX;
        }

        // Spawn Y
        float spawnDisY = Random.Range(minSpawnDistance, maxSpawnDistance);
        if (Random.Range(0, 2) == 0)
        {
            spawnDisY = -spawnDisY;
        }

        // Variance
        if (Random.Range(0, 2) == 0)
        {
            if (spawnDisX > 0)
            {
                spawnDisX -= Random.Range(0, 10);
            }
            else
            {
                spawnDisX += Random.Range(0, 10);
            }
        }
        else
        {
            if (spawnDisY > 0)
            {
                spawnDisY -= Random.Range(0, 10);
            }
            else
            {
                spawnDisY += Random.Range(0, 10);
            }
        }


        Instantiate(enemy, new Vector3(spawnDisX, spawnDisY, 0f), Quaternion.identity);

        canSpawn = true;

    }


}