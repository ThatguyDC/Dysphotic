/*
 * using UnityEngine;

public class CircularSpawner2D : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int spawnCount = 1;
    [SerializeField] private float radius = 5f;
    [SerializeField] private bool parentUnderSpawner = true;
    [SerializeField] private bool randomizeAngles = true; // Option to randomize angles
    [SerializeField] private Vector3 spawnOffset = Vector3.zero; // Offset for position adjustment

    public void SpawnFish()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("No object assigned to spawn!");
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            float angle = randomizeAngles ? Random.Range(0f, 360f) : i * (360f / spawnCount); // Randomize angle if enabled
            Vector3 spawnPosition = GetPositionOnCircle(angle, radius);
            spawnPosition += spawnOffset; // Apply offset

            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            if (parentUnderSpawner)
                spawnedObject.transform.parent = transform;
        }
    }

    private Vector3 GetPositionOnCircle(float angle, float radius)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius, 0) + transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
*/
using UnityEngine;
using System.Collections;

public class FishSummon : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int spawnCount = 10;
    [SerializeField] private float radius = 5f;
    [SerializeField] private bool parentUnderSpawner = true;
    [SerializeField] private bool randomizeAngles = true; // Option to randomize angles
    [SerializeField] private Vector3 spawnOffset = Vector3.zero; // Offset for position adjustment
    public float spawnCooldown = 3f; // Cooldown duration in seconds

    private bool isOnCooldown = false;

    private void Update()
    {

    }

    public void TrySpawn()
    {
        if (!isOnCooldown)
        {
            SpawnObjects();
            StartCoroutine(SpawnCooldown());
        }
    }

    private void SpawnObjects()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("No object assigned to spawn!");
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            float angle = randomizeAngles ? Random.Range(0f, 360f) : i * (360f / spawnCount);
            Vector3 spawnPosition = GetPositionOnCircle(angle, radius);
            spawnPosition += spawnOffset;

            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            if (parentUnderSpawner)
                spawnedObject.transform.parent = transform;
        }
    }

    private Vector3 GetPositionOnCircle(float angle, float radius)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius, 0) + transform.position;
    }

    private IEnumerator SpawnCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(spawnCooldown);
        isOnCooldown = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

