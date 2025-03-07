using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] public AudioSource playerAudio;
    [Header("SFX")]
    [SerializeField] public AudioClip ShootSound;
    [SerializeField] public AudioClip KeySound;
    [SerializeField] public AudioClip PickupBGSound;
    [SerializeField] public AudioClip UnderwaterSound;
    [SerializeField] public AudioClip EnemyDeadSound;

    [Header("Music")]
    [SerializeField] public AudioClip [] LevelMusic; //Used to assign music based on stage/level
    [SerializeField] public AudioClip DiscipleMusic;








    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLevelMusic()
    {
        playerAudio.PlayOneShot(LevelMusic[0]);
    }
    public void PlayOceanMusic()
    {
        playerAudio.PlayOneShot(UnderwaterSound);

    }
    public void PlayShootSound()
    {
        playerAudio.PlayOneShot(ShootSound);
    }
    public void PlayEnemyDeathSound()
    {
        playerAudio.PlayOneShot(EnemyDeadSound);

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
