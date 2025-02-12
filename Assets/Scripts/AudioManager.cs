using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] public AudioSource playerAudio;
    [Header("SFX")]
    [SerializeField] public AudioClip ShootSound;
    [SerializeField] public AudioClip KeySound;
    [SerializeField] public AudioClip PickupBGSound;
    [Header("Music")]
    [SerializeField] public AudioClip IntroMusic;
    [SerializeField] public AudioClip Shelf1Music;
    [SerializeField] public AudioClip Shelf2Music;
    [SerializeField] public AudioClip Shelf3Music;
    [SerializeField] public AudioClip BossMusic;

    [SerializeField] public AudioClip DiscplineMusic;








    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLevelMusic()
    {
        playerAudio.PlayOneShot(IntroMusic);
    }
    public void PlayShootSound()
    {
        playerAudio.PlayOneShot(ShootSound);
    }
    public void PlayKeySound()
    {
        playerAudio.PlayOneShot(KeySound);
    }
    public void PlayBGSound()
    {
        playerAudio.PlayOneShot(PickupBGSound);
    }
}
