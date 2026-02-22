using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("InventoryOpen");
            if (inventory.activeSelf)
            {
              inventory.SetActive(false);
                Time.timeScale = 1f;
            } else
            {
                inventory.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
