using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathScript : MonoBehaviour
{
    public GameObject retry;
    public GameObject quit;
    public AudioSource roar;

    public Animator deathPanelAnimator;

    void Awake()
    {
        retry.SetActive(false);
        quit.SetActive(false);
        deathPanelAnimator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Trigger detection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("I killed the rat");
            roar.Play();
            StartCoroutine(DeathScene());
        }
    }

    IEnumerator DeathScene()
    {
        yield return new WaitForSeconds(0.5f);
        deathPanelAnimator.gameObject.SetActive(true);
        deathPanelAnimator.Play("Death");
        
        retry.SetActive(true);
        quit.SetActive(true);
        
        //Time.timeScale = 0f;
    }
}
