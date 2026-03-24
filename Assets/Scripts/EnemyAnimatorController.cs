using UnityEngine;
using Pathfinding;

public class EnemyAnimatorController : MonoBehaviour
{
    private Animator animator;
    private AIPath aiPath;

    Vector2 smoothDirection;
    float smoothSpeed = 10f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        aiPath = GetComponent<AIPath>();
    }

    void Update()
    {
        Vector2 velocity = aiPath.desiredVelocity;
        float speed = velocity.magnitude;

        // Send speed to animator
        animator.SetFloat("Speed", speed);

        // Only update direction if actually moving
        if (speed > 0.1f)
        {
            velocity.Normalize();
            smoothDirection = Vector2.Lerp(smoothDirection, velocity, Time.deltaTime * smoothSpeed);

            animator.SetFloat("Horizontal", smoothDirection.x);
            animator.SetFloat("Vertical", smoothDirection.y);
        }
    }
}
