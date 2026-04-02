using UnityEngine;
using Pathfinding;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 8f;
    public Animator animator;
    public Animator animHide;

    private SpriteRenderer rend;
    private bool canHide = false;
    private bool hiding = false;

    private IAstarAI[] enemies;
    private Vector2 movement;

    public GameObject hideUI;

    private void Awake()
    {
        hideUI.SetActive(false);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

        AIPath[] aiPaths = FindObjectsOfType<AIPath> ();
        enemies = new IAstarAI[aiPaths.Length];
        for (int i = 0; i < aiPaths.Length; i++)
        {
            enemies[i] = aiPaths[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Toggle hiding
        if (canHide && Input.GetKeyDown(KeyCode.E))
        {
            hiding = !hiding;   // <-- toggle on/off
            UpdateHidingState();
        }

        if (!hiding)
        {
            foreach (var enemy in enemies)
            {
                enemy.destination = transform.position;
            }
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateHidingState()
    {
        animHide.SetBool("IsHiding", hiding);
        
        if (hiding)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            rend.sortingOrder = 2;
            hideUI.SetActive(false);

            animHide.Play("HideFadingIn", 0, 0f);

            foreach (var enemy in enemies)
            {
                var enemyComponent = enemy as Component;
                var wander = enemyComponent.GetComponent<EnemyWander>();
                if (wander != null)
                    wander.StartWandering();

                enemy.canMove = true;   // allow wandering
            }
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            rend.sortingOrder = 5;

            animHide.Play("HideFadeOut", 0, 0f);

            foreach (var enemy in enemies)
            {
                var enemyComponent = enemy as Component;
                var wander = enemyComponent.GetComponent<EnemyWander>();
                if (wander != null)
                    wander.StopWandering();

                enemy.canMove = true;
                enemy.destination = transform.position; // resume chasing
            }
        }
    }

    // Trigger detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HidingSpot"))
            canHide = true;
        hideUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HidingSpot"))
        {
            canHide = false;
            hiding = false;
            hideUI.SetActive(false);
            UpdateHidingState();
        }
    }

    /*
    // If triggered, it will check if it has the tag and player will be able to hide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HidingSpot"))
        {
            canHide = true;
        }
    }

    // Once player leave trigger, they will not be able to hide anymore
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HidingSpot"))
        {
            canHide = false;
            hiding = false;
            UpdateHidingState();
        }
    }*/
}
