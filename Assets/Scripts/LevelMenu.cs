using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void Level2()
    {
        SceneManager.LoadScene("FirstChase");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
}
