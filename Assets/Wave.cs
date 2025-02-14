using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour
{

    public List<Transform> enemiesInWave = new List<Transform>();

    public GameObject player;

    private Vector2 facingDirection;
    [SerializeField] private float WaveLifespan = 2f;
    [SerializeField] private float waveSpeed = 5f;


    private Rigidbody2D waveRb;


    private Vector2 waveDirection = new Vector2(0,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveRb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate(){

        if(gameObject.activeSelf){

            waveRb.linearVelocity = waveDirection * waveSpeed;
            
        }

    }

    public IEnumerator SpawnWave(){
        Debug.Log("Co running");
        //using just transform.position works cause this script is in the player
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        waveDirection = player.transform.right;

        yield return new WaitForSeconds(WaveLifespan-0.5f);

        ReleaseEnemiesFromWave();

        yield return new WaitForEndOfFrame();

        gameObject.SetActive(false);
    }
  

  void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Enemy")){
            
            GameObject enemy = other.gameObject;

            enemy.transform.SetParent(transform);

            enemiesInWave.Add(enemy.transform);

        }
    }

    void ReleaseEnemiesFromWave(){
        foreach(Transform enemy in enemiesInWave){
            
            enemy.SetParent(null);
        }

        enemiesInWave.Clear();
    }
}
