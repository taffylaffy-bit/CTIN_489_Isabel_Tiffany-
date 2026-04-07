using UnityEngine;
using Pathfinding;

public class CutSceneTrigger : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject playerObjective;
    public GameObject pressE;

    private IAstarAI[] enemies;

    public void Start()
    {
        fadeOut.SetActive(false);

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
            fadeOut.SetActive(true);
            playerObjective.SetActive(false);
            pressE.SetActive(false);

            // Stop enemies from chasing
            foreach (var enemy in enemies)
            {
                enemy.canMove = false;
                enemy.destination = enemy.position; // freeze immediately
                Debug.Log("Enemy is paused");
            }
        }
    }
}
