using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    public GameObject fadeOut;

    public void Start()
    {
        fadeOut.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        fadeOut.SetActive(true);
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    fadeOut.SetActive(true);
        //}
    }
}
