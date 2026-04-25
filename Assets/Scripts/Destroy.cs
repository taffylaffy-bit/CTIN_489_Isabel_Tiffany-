using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destroy : MonoBehaviour
{
    public GameObject playerObjective;
    public GameObject ingredientCounter;
    public GameObject skipButton;
    public AudioSource audio;
    public Animator fadeOut;

    void Awake()
    {
        playerObjective.SetActive(false);
        ingredientCounter.SetActive(false);
        skipButton.SetActive(false);
    }

    void Start()
    {
        Destroy(gameObject, 21f); // destroy THIS object
        StartCoroutine(SkipButton());
    }

    void OnDestroy()
    {
        if (playerObjective != null)
        {
            playerObjective.SetActive(true);
            ingredientCounter.SetActive(true);
            skipButton.SetActive(false);
            fadeOut.Play("Cut Scene Fade Out");
            audio.Play();
        }
             
        //if (ingredientCounter != null)
            
    }

    public void Skip()
    {
        fadeOut.Play("Cut Scene Fade Out");
        Destroy(gameObject);
        skipButton.SetActive(false);
        //StartCoroutine(SkipCutScene());
    }

    IEnumerator SkipButton()
    {
        yield return new WaitForSeconds(2f);
        skipButton.SetActive(true);
    }
}
