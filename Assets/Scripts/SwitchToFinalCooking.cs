using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToFinalCooking : MonoBehaviour
{
    private bool playerInside = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Once the player is in the trigger and pressed space, the FinalCooking function call be called
        if (playerInside && Input.GetKeyDown(KeyCode.Space))
        {
            FinalCookingScene();
        }
    }

    // Once in trigger, playerinside is true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Player entered cooking area");
        }
    }

    // This moves the player to the next scene, the Distorted Cooking
    void FinalCookingScene()
    {
        SceneManager.LoadScene("DistortedCooking");
        Debug.Log("Pressing Space and loading DistortedCooking Scene");
    }
}
