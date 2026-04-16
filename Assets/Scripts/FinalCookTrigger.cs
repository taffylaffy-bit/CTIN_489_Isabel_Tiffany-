using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FinalCookTrigger : MonoBehaviour
{
    [Header("UI Output (Cooked Result)")]
    [SerializeField] private Image outputImage;
    [SerializeField] private Sprite cookedSprite;

    [Header("UI Background")]
    [SerializeField] private Image psychBackgroundImage;
    [SerializeField] private Sprite psychOilBackground;

    [Header("Audio")]
    public AudioSource oilSizzle;
    public AudioSource gore;
    public AudioSource slurp;

    [Header("UI Objects")]
    public GameObject finalCookUI;
    public GameObject cookingIns;
    public GameObject friedBrains;
    public GameObject gameEndingUI;
    
    [Header("Ending Animation")]
    public Animator gameEndingAnimator;
    public Animator gameEndingUIAnim;
    
    private int ingredientCount = 0;

    public void Awake()
    {
        finalCookUI.SetActive(false);
        friedBrains.SetActive(false);
        gameEndingUI.SetActive(false);
        outputImage.gameObject.SetActive(false);
    }


    public void CheckOverlap(RectTransform draggedItem, string tag)
    {
        RectTransform triggerRect = GetComponent<RectTransform>();

        if (!RectOverlaps(triggerRect, draggedItem))
            return;

        // -----------------------------
        // OIL
        // -----------------------------
        if (tag == "Oil")
        {
            psychBackgroundImage.sprite = psychOilBackground;
            draggedItem.gameObject.SetActive(false);
            oilSizzle.Play();
            ingredientCount++;
            return;
        }

        // -----------------------------
        // MOP (visual only)
        // -----------------------------
        if (tag == "Mop")
        {
            friedBrains.SetActive(true);
            return;
        }

        // -----------------------------
        // KETCHUP or BRAIN
        // -----------------------------
        if (tag == "Ketchup" || tag == "Brain")
        {
            ingredientCount++;
            friedBrains.SetActive(false);
            draggedItem.gameObject.SetActive(false);

            if (ingredientCount >= 3)
            {
                outputImage.sprite = cookedSprite;
                outputImage.gameObject.SetActive(true);
                StartCoroutine(CookFailScreen());
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
            b.rect.width * b.lossyScale.x,
            b.rect.height * b.lossyScale.y
        );

        return rectA.Overlaps(rectB);
    }

    IEnumerator CookFailScreen()
    {
        yield return new WaitForSeconds(0.5f);
        
        finalCookUI.SetActive(true);
        cookingIns.SetActive(false);
        outputImage.gameObject.SetActive(false);
        
        StartCoroutine(GameEnding());
    }

    IEnumerator GameEnding()
    {
        yield return new WaitForSeconds(10f);
        
        gameEndingAnimator.gameObject.SetActive(true);
        gameEndingAnimator.Play("GameEnding");

        gameEndingUIAnim.gameObject.SetActive(true);
        gameEndingUIAnim.Play("GameEndingUI");

        oilSizzle.Stop();
        gore.Play();
        slurp.Play();
        
        gameEndingUI.SetActive(true);
    }

}
