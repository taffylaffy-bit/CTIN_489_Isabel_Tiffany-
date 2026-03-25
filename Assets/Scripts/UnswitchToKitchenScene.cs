using UnityEngine;
using UnityEngine.SceneManagement;

public class UnswitchToKitchenScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitCookingScene();
        }
    }

    void ExitCookingScene()
    {
        SceneManager.LoadScene("FirstChase");
        Debug.Log("Pressing Z and loading Chase Scene");
    }
}
