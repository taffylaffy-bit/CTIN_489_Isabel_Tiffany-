using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelMenu;

    private void Awake()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void Levels()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

}
