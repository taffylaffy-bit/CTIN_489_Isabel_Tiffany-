using UnityEngine;

public class PickUP : MonoBehaviour
{
    private bool canPickUp;
    private bool pickedUp;

    public GameObject pickUpText;
    public GameObject item;

    public IngredientCounter counter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pickUpText.SetActive(false);
    }

    void Start()
    {
        counter = FindFirstObjectByType<IngredientCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp && !pickedUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
    }

    void PickUpItem()
    {
        pickedUp = true;

        counter.AddIngredient();

        pickUpText.SetActive(false);

        item.SetActive(false);

        // destroys gameobject after a quick second
        Destroy(gameObject, 0.01f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered: " + other.name);

        if (pickedUp) return;

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
