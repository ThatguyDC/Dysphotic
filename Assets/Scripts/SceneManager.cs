using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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
