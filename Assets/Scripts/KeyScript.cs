using UnityEditor;
using UnityEngine;
public class KeyScript : MonoBehaviour
{
    [Header("Script Comms")]
    public Player PlayerScript;
    public AudioManager AM;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerScript.keyCount += 1;
            PlayerPrefs.SetInt("KeyCount", PlayerScript.keyCount);
            AM.PlayKeySound();
            AM.PlayBGSound();
            GameObject.Destroy(gameObject); //sewer slide

        }
    }
}

