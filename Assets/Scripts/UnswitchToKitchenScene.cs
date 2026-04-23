using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UnswitchToKitchenScene : MonoBehaviour
{
    
    public Animator animator;
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            panel.SetActive(true);
            StartCoroutine(ExitCookingScene());
            animator.Play("SwitchToChase");
            Debug.Log("Loading Chase Scene...");
        }
    }

    IEnumerator ExitCookingScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FirstChase");
        
    }
}
