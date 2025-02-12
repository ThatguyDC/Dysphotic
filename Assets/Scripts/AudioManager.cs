using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] public AudioSource playerAudio;
    [Header("Audio Clips")]
    [SerializeField] public AudioClip ShootSound;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayShootSound()
    {
        playerAudio.PlayOneShot(ShootSound);
    }
}
