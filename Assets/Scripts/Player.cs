using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Script Comms")]
    public AudioManager AM;
    public uiManager UM;
    public FishSummon FishSummoner;
    public Wave WaveSummoner;

    [Header("Player Audio")]
    [SerializeField] private AudioSource PlayerAudioSrc;

    [Header("Movement")]
    public float moveSpeed = 5f;       // Maximum speed
    public float acceleration = 10f;   // How fast the player reaches max speed
    public float deceleration = 5f;    // How fast the player slows down
    private Vector2 velocity;          // Stores the current movement speed
    private Vector2 movement;

    private Vector2 screenBounds;

    


    [Header("Combat")]
    public float playerHealth;
    public float maxPlayerHealth;
    private float minPlayerHealth = 0;


    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;

    [Header("Abilities")]

    //Wave
    public GameObject WaveObject;

    [Header("Progression")]

    public float gameTime = 0f;
    public int killThreshold = 100;
    public bool AmuletSpawned;

    public int keyCount = 0; //# of stages the player has cleared. Update this with playerPrefs
    public int killCount = 0; //amt of enemies killed by player and their abilities
    [SerializeField] private GameObject Amulet;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        keyCount = PlayerPrefs.GetInt("KeyCount");
        AM.PlayLevelMusic();
        AM.PlayOceanMusic();
        UM = GameObject.FindFirstObjectByType<uiManager>();
    }

    void Update()
    {
        Move();
        Shoot(); 
        Rotate(); //rotate the player while moving
        FishSummon(); //fish minions can be summoned
        //WaveSummon(); //wave ability 
        CheckLevelState(); // is time up/player dead? 
        ClampPlayerHealth(); //limits health to upper bounds/zero when dead 
    }

    void FixedUpdate()
    {
        transform.position += (Vector3)movement * moveSpeed * Time.fixedDeltaTime;

    }

    #region Movement

    
    
    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 inputDirection = new Vector2(moveX, moveY).normalized;

        if (inputDirection.magnitude > 0)
        {
            // Accelerate towards input direction
            velocity = Vector2.Lerp(velocity, inputDirection * moveSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // Gradually slow down when no input is given
            velocity = Vector2.Lerp(velocity, Vector2.zero, deceleration * Time.deltaTime);
        }
        
        // Apply movement
        transform.position += (Vector3)(velocity * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x * 2, screenBounds.x * 2);
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y * 2, screenBounds.y * 2);

        Vector2 pos = transform.position;
        pos.x = clampedX;
        pos.y = clampedY;
        transform.position = pos;
    }
    void Rotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    #endregion

    #region Combat/Abilities

    void ClampPlayerHealth()
    {
        Mathf.Clamp(playerHealth, minPlayerHealth, maxPlayerHealth);
    }
    void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + fireRate;
            AM.PlayShootSound();


        }
    }
    //Summon 1
    void FishSummon()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            FishSummoner.TrySpawn(); 
        }
            
    }

    /*
    //Summon 2
    void WaveSummon()
    {
        if (Input.GetKey(KeyCode.E))
        {
            WaveSummoner.gameObject.SetActive(true);
            StartCoroutine(WaveSummoner.SpawnWave());
        }
    }
    //Summon 3
    
    void WaveSummon()
    {
        if (Input.GetKey(KeyCode.E))
        {
            WaveSummoner.gameObject.SetActive(true);
            StartCoroutine(WaveSummoner.SpawnWave());
        }
    }
    */

    #endregion

    #region Progression

    void CheckLevelState()
    {
        if (!AmuletSpawned && (UM.timeLeft <= 1 || killCount > killThreshold)) //spawns the amulet so player can progress
        {
        Amulet.SetActive(true);
        AmuletSpawned = true;
        }
        else
        {
            //Debug.Log("didnt hit amulet");
            //player probably dead
        }
        
    }




    #endregion

    #region Collisions


    #endregion
}
