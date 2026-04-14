using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CutSceneTrigger : MonoBehaviour
{
    public GameObject endingCutScene;
    public GameObject playerObjective;
    public GameObject pressE;

    public GameObject finalMeal;

    public AudioSource backgroundMusic;

    private IAstarAI[] enemies;

    public void Start()
    {
        endingCutScene.SetActive(false);
        finalMeal.SetActive(false);

        AIPath[] aiPaths = FindObjectsOfType<AIPath>();
        enemies = new IAstarAI[aiPaths.Length];
        for (int i = 0; i < aiPaths.Length; i++)
        {
            enemies[i] = aiPaths[i];
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            endingCutScene.SetActive(true);
            playerObjective.SetActive(false);
            pressE.SetActive(false);
            backgroundMusic.Stop();

            StartCoroutine(LoadFinalScene());

            // Stop enemies from chasing
            foreach (var enemy in enemies)
            {
                enemy.canMove = false;
                enemy.destination = enemy.position; // freeze immediately
                Debug.Log("Enemy is paused");
            }
        }
    }

    IEnumerator LoadFinalScene()
    {
        yield return new WaitForSeconds(17f);
        finalMeal.SetActive(true);
    }

}
