using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [Header("Script Comms")]

    public Player PlayerScript;

    [Header("Scene Transitions")]

    public Scene scene;
    [SerializeField] RectTransform fader;

    void Start()
    {

        scene = SceneManager.GetActiveScene();
        if (scene.name == "Main Menu")
        {
            fader.gameObject.SetActive(true);
            LeanTween.scale(fader, Vector3.zero, 0);
        }

        else
        {
            fader.gameObject.SetActive(true);
            LeanTween.scale(fader, Vector3.zero, 1.0f);
            //LeanTween.scale(fader, new Vector3(1, 1, 1), 1.0f);
        }
    }


    public void LoadMainMenu()
    {
        
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadShelf1()
    {
        LeanTween.scale(fader, new Vector3(1, 1, 1), 1.0f).setOnComplete(() => {
            SceneManager.LoadScene("Shelf1");
        });
        
    }

    public void LoadShelf2()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });
        SceneManager.LoadScene("Shelf2");
    }

    public void LoadShelf3()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });
        SceneManager.LoadScene("Shelf3");
    }

    public void LoadHadalEclipse()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });
        SceneManager.LoadScene("Hadal Eclipse");
    }

    public void QuitGame()
    {
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });
        Application.Quit();
    }
}
