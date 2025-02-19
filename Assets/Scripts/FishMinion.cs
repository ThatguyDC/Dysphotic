using UnityEngine;

public class FishMinion : MonoBehaviour
{
    public string targetTag = "Enemy"; // Tag to track
    public float speed = 5f; // Speed of tracking
    public float damage = 1f; //how much dmg to deal to its target
    private Transform target; // The nearest target to track with the specified tag

    void Update()
    {
        FindNearestTarget();
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }

    void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTarget = null;

        foreach (GameObject potentialTarget in targets)
        {
            float distance = Vector2.Distance(transform.position, potentialTarget.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestTarget = potentialTarget;
            }
        }

        if (nearestTarget != null)
        {
            target = nearestTarget.transform;
        }
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void RotateTowardsTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    //When colliding with an enemy tag, check the target's health and decrease it by dmgAmt;

}
