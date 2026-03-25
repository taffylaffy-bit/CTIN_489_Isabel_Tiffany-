using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToCooking : MonoBehaviour
{
    private bool playerInside = false;

    public GameObject interactText;
    public IngredientCounter ingredientCounter;

    void Awake()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        // Only allow cooking if player is inside AND has 3 ingredients
        if (playerInside && ingredientCounter.ingredientAmount >= 3)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                LoadCookingScene();
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    private void LoadCookingScene()
    {
        SceneManager.LoadScene("CookingScene");
        Debug.Log("Loading Cooking Scene...");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Player entered cooking area");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("Player left cooking area");
        }
    }

}
