using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 10f;
    public float maxRange = 5f;
    public float damage = 1f;
    public LayerMask collisionLayers;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MoveBullet();
        CheckDistance();
    }

    void MoveBullet()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    void CheckDistance()
    {
        if (Vector3.Distance(startPosition, transform.position) >= maxRange)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy") 
        {
            Debug.Log("hit");
        }
        if ((collisionLayers & (1 << col.gameObject.layer)) != 0)
        {
            Destroy(gameObject);
            // Optionally, add effects or damage logic here
        }
    }
}
