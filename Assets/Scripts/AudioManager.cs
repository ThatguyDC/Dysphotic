using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] public AudioSource playerAudio;
    [SerializeField] public AudioSource menuAudio;


    [Header("SFX")]
    [SerializeField] public AudioClip ShootSound;
    [SerializeField] public AudioClip KeySound;
    [SerializeField] public AudioClip PickupBGSound;
    [SerializeField] public AudioClip UnderwaterSound;
    [SerializeField] public AudioClip EnemyDeadSound;

    //UI SFX
    [SerializeField] public AudioClip ButtonClick;


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

    //Music

    public void PlayLevelMusic()
    {
        playerAudio.PlayOneShot(LevelMusic[0]);
    }
    public void PlayOceanMusic()
    {
        playerAudio.PlayOneShot(UnderwaterSound);

    }


    //SFX
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

    //UI SFX
    public void PlayClickSound()
    {
        menuAudio.PlayOneShot(ButtonClick);
    }

}
