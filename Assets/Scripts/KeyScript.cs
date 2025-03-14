using UnityEditor;
using UnityEngine;
public class KeyScript : MonoBehaviour
{
    [Header("Script Comms")]
    public Player PlayerScript;
    public AudioManager AM;
    public SceneLoader SL;
    

    

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

            if (PlayerScript.keyCount == 1)
            {
                SL.LoadShelf2();
            }

            //Shelf 3 load condition
            else if (PlayerScript.keyCount == 2)
            {
                SL.LoadShelf3();
            }
            else if (PlayerScript.keyCount == 3)
            {
                SL.LoadHadalEclipse();
            }
            AM.PlayKeySound();
            AM.PlayBGSound();
            GameObject.Destroy(gameObject); //sewer slide

        }
    }
}

