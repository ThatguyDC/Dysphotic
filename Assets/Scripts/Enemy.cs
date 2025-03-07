using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public class Enemy : MonoBehaviour
{
    [Header("Script Comms")]
    public uiManager uiScript;
    public AudioManager AM;
    public EnemySpawnSystem ESS;
    public Player player;

    [Header("Enemy Info")]
    public float Health = 100f; //total health remaining
    private float minHealth = 0f;
    private float maxHealth = 1000f; //upper health limit
    [SerializeField] private bool isDead; //true = dead, false = alive
    public float xpAmt;

    [Header("Combat")]
    public float dmgTaken; //last value of health removed
    public float dmgToPlayer = 0f;

    [Header("Ai Params")]
    public GameObject playerObj;
    public float enemySpeed;
    private float enemyDistance;
    public float distanceBetween;


    void Start()
    {
        //set starting values  
        playerObj = GameObject.FindGameObjectWithTag("Player");
        uiScript = GameObject.FindFirstObjectByType<uiManager>();
        AM = GameObject.FindFirstObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        enemyDistance = Vector2.Distance(transform.position, playerObj.transform.position);

        Vector2 direction = playerObj.transform.position - transform.position;

        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;



        if (enemyDistance > distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerObj.transform.position, enemySpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

    }

    

    public void EnemyDie()
    {
        if (isDead) // Ensure XP is only added once
        {
            
            uiScript.IncreaseXP(xpAmt); // Transfer XP correctly
            playerObj.GetComponent<Player>().killCount += 1;
            AM.PlayEnemyDeathSound();
            Destroy(gameObject); // Destroy enemy after XP is granted
        }
    }

    public void TakeDamage(float dmg)
    {
        dmgTaken = dmg;
        Health -= dmgTaken;
        if (Health <= minHealth && !isDead) // Ensure XP is only given once
        {
            isDead = true;
            EnemyDie();
        }
    }

    void DamagePlayer() //called in collision after attack timer cycle
    {
        if (playerObj.GetComponent<Player>().playerHealth > 0) //check if player is alive
        {
            playerObj.GetComponent<Player>().playerHealth -= dmgToPlayer; //dmg them if true
            Debug.Log("dmg'd player");
        }
        else
        {
            //don't bother damaging
        }
        
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
                TakeDamage(dmgTaken);
            }
        }

        if (col.gameObject.CompareTag("pDmgVolume"))  //&& Time.time >= nextAttackTime) //Once the attack cooldown cycles, dmg player and reset timer
        {
            DamagePlayer();
        }
        else
        {

        }
    }


    }

    #endregion
