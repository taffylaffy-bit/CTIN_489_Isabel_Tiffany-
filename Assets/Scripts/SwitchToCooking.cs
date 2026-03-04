using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToCooking : MonoBehaviour
{
    private bool canCook = false;
    private bool cooking = false;

    public GameObject interactText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (canCook && Input.GetKeyDown(KeyCode.Z))
        {
            LoadCookingScnen();
        }
    }

    private void LoadCookingScnen()
    {
        SceneManager.LoadScene("CookingScene");
        Debug.Log("Pressing Z and loading Scene");

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered: " + other.name);
        //canCook = true;
        //Debug.Log("Has entered trigger");

        if (other.CompareTag("Player"))
        {
            canCook = true;
            Debug.Log("Has entered trigger");
            interactText.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canCook = false;
            Debug.Log("Exited trigger");
            interactText.SetActive(false);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canCook = true;
        }
    }*/
}
