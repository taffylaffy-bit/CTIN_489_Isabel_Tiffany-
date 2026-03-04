using UnityEngine;

public class PickUP : MonoBehaviour
{
    private bool canPickUp;

    public GameObject pickUpText;
    public GameObject item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pickUpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
    }

    private void PickUpItem()
    {
        item.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered: " + other.name);

        if (other.CompareTag("Player"))
        {
            canPickUp = true;
            Debug.Log("Can Pick Up");
            pickUpText.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false;
            Debug.Log("Can no longer Pick Up");
            pickUpText.SetActive(false);
        }
    }
}
