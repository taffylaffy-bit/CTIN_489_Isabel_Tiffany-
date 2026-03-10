using UnityEngine;
using TMPro;

public class IngredientCounter : MonoBehaviour
{
    public TMP_Text counterText;

    private int ingredientAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateText();
    }

    public void AddIngredient()
    {
        ingredientAmount++;
        UpdateText();
    }

    // Update is called once per frame
    void UpdateText()
    {
        counterText.text = "Ingredient: " + ingredientAmount + "/3";
    }
}
