using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CookTrigger : MonoBehaviour
{
    [Header("UI Output (Cooked Result)")]
    [SerializeField] private Image outputImage; 
    [SerializeField] private Sprite cookedSprite;

    [Header("UI Background")]
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite oilBackground;

    public AudioSource oilSizzle;

    public GameObject cookFailUI;
    public GameObject cookingIns;
    public GameObject friedNoodles;

    private int ingredientCount = 0;

    public void Awake()
    {
        cookFailUI.SetActive(false);
        friedNoodles.SetActive(false);
    }


    public void CheckOverlap(RectTransform draggedItem, string tag)
    {
        RectTransform triggerRect = GetComponent<RectTransform>();

        if (RectOverlaps(triggerRect, draggedItem))
        {
            if (tag == "Oil")
            {
                backgroundImage.sprite = oilBackground;
                draggedItem.gameObject.SetActive(false);
                oilSizzle.Play();
                ingredientCount++;
                return;

                if (tag == "Mop")
                {
                    friedNoodles.SetActive(true);
                }
            }

          

            if (tag == "Ketchup" || tag == "Mop")
            {
                ingredientCount++;
                Debug.Log("Cooked sprite applied!");
                friedNoodles.SetActive(false);

                // Hide the ingredient
                draggedItem.gameObject.SetActive(false);

                if (ingredientCount >= 3)
                {
                    outputImage.gameObject.SetActive(true);   
                    outputImage.sprite = cookedSprite;
                    StartCoroutine(CookFailScreen());
                }
            }
        }
    }

    private bool RectOverlaps(RectTransform a, RectTransform b)
    {
        Rect rectA = new Rect(
            a.position.x - a.rect.width * a.lossyScale.x / 2,
            a.position.y - a.rect.height * a.lossyScale.y / 2,
            a.rect.width * a.lossyScale.x,
            a.rect.height * a.lossyScale.y
        );

        Rect rectB = new Rect(
            b.position.x - b.rect.width * b.lossyScale.x / 2,
            b.position.y - b.rect.height * b.lossyScale.y / 2,
            b.rect.width * b.lossyScale.y,
            b.rect.height * b.lossyScale.y
        );

        return rectA.Overlaps(rectB);
    }

    IEnumerator CookFailScreen()
    {
        yield return new WaitForSeconds(0.5f);
        cookFailUI.SetActive(true);
        cookingIns.SetActive(false);
        outputImage.gameObject.SetActive(false);
    }
}

