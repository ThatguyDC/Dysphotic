using Unity.VisualScripting;
using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    public GameObject body;
    public GameObject tail;

    private int length = 8;
    private GameObject current;
    private GameObject last;
    private SpriteRenderer sr;

    [Header("Ai Params")]
    public GameObject player;
    public float enemySpeed;
    private float enemyDistance;
    public float distanceBetween;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        for (int i = length; i > 0; i--)
        {
            if (i == 1)
            {
                current = Instantiate(tail, last.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
                current.GetComponent<FollowScript>().setFollow(last.transform.GetChild(0).gameObject);
            }
            else if (i == length)
            {
                current = Instantiate(body, gameObject.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
                current.GetComponent<FollowScript>().setFollow(gameObject.transform.GetChild(0).gameObject);
                last = current;
            }
            else
            {
                current = Instantiate(body, last.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
                current.GetComponent<FollowScript>().setFollow(last.transform.GetChild(0).gameObject);
                last = current;
            }
        }
        player = GameObject.FindWithTag("Player");

    }

    private void Update()
    {
        if(transform.rotation.eulerAngles.z < 180)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        enemyDistance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;



        if (enemyDistance > distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

    }
}
