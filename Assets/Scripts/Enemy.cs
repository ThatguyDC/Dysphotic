using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public class Enemy : MonoBehaviour
{
    [Header("Script Comms")]
    private uiManager uiScript;


    [Header("Enemy Info")]
    public float Health = 100f; //total health remaining
    private float minHealth = 0f;
    private float maxHealth = 1000f; //upper health limit
    [SerializeField] private bool isDead; //true = dead, false = alive
    public float xpAmt;

    [Header("Combat")]
    public float dmgTaken; //last value of health removed
    private float dmgToPlayer = 0f;

    [Header("Ai Params")]
    public GameObject player;
    public float enemySpeed;
    private float enemyDistance;
    public float distanceBetween;


    void Start()
    {
        //set starting health/dmg values  
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        EnemyDie(); 
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

    public void EnemyDie()
    {

        if (Health <= minHealth)
        {
            isDead = true;
            GameObject.Destroy(gameObject); //sewer slide
        }
    }

    private void TakeDamage()
    {
        Health -= dmgTaken;
        Debug.Log(dmgTaken);

    }

    private void GrantXP()
    {
        uiScript.currentXP += xpAmt;
    }

    public void ResetHealth()
    {
        Health = maxHealth;
    }

    // Change XP (increase or decrease by amount)


    #region Collisions
    public void OnTriggerEnter2D(Collider2D col)
    {
        // Check if the collided object has the "Bullet" tag
        if (col.gameObject.CompareTag("Bullet"))
        {
            // Get the Bullet component from the collided object
            Bullet bullet = col.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                // Assign the damage value to the bullet
                dmgTaken = bullet.damage;

                // Call the TakeDamage method
                TakeDamage();
            }
        }
    }

    #endregion


}
