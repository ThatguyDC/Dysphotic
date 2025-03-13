using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.Save();

        PlayerPrefs.SetInt(KeyCount, 0);
        PlayerPrefs.Save();
    }
    private void Update()
    {

        //Shelf 1 is loaded from main menu

        //Shelf 2 load condition
        if (PlayerPrefs.KeyCount == 1)
        {
            LoadShelf2();
        }

        //Shelf 3 load condition
        else if (PlayerPrefs.KeyCount == 2)
        {
            LoadShelf3();
        }
        else if (PlayerPrefs.KeyCount == 3)
        {
            LoadHadalEclipse();
        }

        else
        {
            //Don't load any scenes out of key bounds
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadShelf1()
    {
        SceneManager.LoadScene("Shelf1");
    }

    public void LoadShelf2()
    {
        SceneManager.LoadScene("Shelf2");
    }

    public void LoadShelf3()
    {
        SceneManager.LoadScene("Shelf3");
    }

    public void LoadHadalEclipse()
    {
        SceneManager.LoadScene("Hadal Eclipse");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
