using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject[] mainMenuObjs;
    public GameObject settingsMenu;

    public void OpenSettings()
    {
        Debug.Log("Hello!");
        foreach (GameObject obj in mainMenuObjs)
        {
            obj.SetActive(false);
        }

        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        foreach (GameObject obj in mainMenuObjs)
        {
            obj.SetActive(true);
        }

        settingsMenu.SetActive(false);
    }
}
