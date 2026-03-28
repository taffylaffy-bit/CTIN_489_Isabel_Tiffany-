using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject playerObjective;
    public GameObject ingredientCounter;

    void Awake()
    {
        playerObjective.SetActive(false);
        ingredientCounter.SetActive(false);
    }

    void Start()
    {
        Destroy(gameObject, 28f); // destroy THIS object
    }

    void OnDestroy()
    {
        if (playerObjective != null)
            playerObjective.SetActive(true);
        if (ingredientCounter != null)
            ingredientCounter.SetActive(true);
    }

}
