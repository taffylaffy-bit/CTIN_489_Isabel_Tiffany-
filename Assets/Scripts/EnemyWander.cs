using UnityEngine;
using Pathfinding;

public class EnemyWander : MonoBehaviour
{
    public float wanderRadius = 20f;
    public float wanderInterval = 3f;

    private AIPath ai;          // use AIPath directly
    private float timer;
    private bool isWandering = false;
    private Vector3 centerPos;

    private void Start()
    {
        ai = GetComponent<AIPath>();
        centerPos = transform.position;
        timer = wanderInterval;
        isWandering = false;   // enemy starts in chase mode ✔
    }

    private void Update()
    {
        if (!isWandering || ai == null) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // pick a random point around the center
            Vector3 rawPoint = centerPos + (Vector3)(Random.insideUnitCircle * wanderRadius);

            // snap to nearest node on the graph
            var nn = AstarPath.active.GetNearest(rawPoint);
            Vector3 targetPos = (Vector3)nn.position;

            ai.destination = targetPos;
            ai.SearchPath();

            timer = wanderInterval;

            Debug.Log("Wander target: " + targetPos);
        }
    }

    public void StartWandering()
    {
        isWandering = true;
        timer = 0f;
    }

    public void StopWandering()
    {
        isWandering = false;
    }
}
