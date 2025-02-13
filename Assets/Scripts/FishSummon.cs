using UnityEngine;

public class CircularSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int spawnCount = 10;
    [SerializeField] private float radius = 5f;
    [SerializeField] private bool parentUnderSpawner = true;

    public void SpawnObjects()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("No object assigned to spawn!");
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            float angle = i * (360f / spawnCount); // Evenly distribute objects
            Vector3 spawnPosition = GetPositionOnCircle(angle, radius);
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            if (parentUnderSpawner)
                spawnedObject.transform.parent = transform;
        }
    }

    private Vector3 GetPositionOnCircle(float angle, float radius)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radian) * radius, 0, Mathf.Sin(radian) * radius) + transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
