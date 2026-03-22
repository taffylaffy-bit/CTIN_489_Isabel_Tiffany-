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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ExitCookingScene();
        }
    }

    void ExitCookingScene()
    {
        SceneManager.LoadScene("OpeningSequence");
        Debug.Log("Pressing Z and loading Opening Scene");
    }
}
