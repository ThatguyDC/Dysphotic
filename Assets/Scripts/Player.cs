using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Script Comms")]
    public AudioManager AM;
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

    [Header("Combat")]
    public float playerHealth;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;

    [Header("Abilities")]

    //Wave
    public GameObject WaveObject;

    [Header("Progression")]
    public int keyCount = 0; //# of stages the player has cleared. Update this with playerPrefs

    void Start()
    {
        keyCount = PlayerPrefs.GetInt("KeyCount");
        AM.PlayLevelMusic();
        AM.PlayOceanMusic();
    }

    void Update()
    {
        Move();
        Shoot();
        Rotate();
        FishSummon();
        WaveSummon();
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
            FishSummoner.TrySpawn(); //
        }
            
    }
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
    /*
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





    #endregion

    #region Collisions

    private void OnTriggerEnter2D(Collider2D collision)
    {
       //Debug.Log(collision.tag);

    }

    #endregion
}
