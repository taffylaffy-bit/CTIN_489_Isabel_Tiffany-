using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 8f;
    public Animator animator;

    private SpriteRenderer rend;

    private bool canHide = false;
    private bool hiding = false;

    Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
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

        // Toggle hiding only when inside a hiding spot
        if (canHide && Input.GetKeyDown(KeyCode.E))
        {
            hiding = true; // <-- the toggle 
            UpdateHidingState();
        }
    }

    private void FixedUpdate()
    {
        // Movement 
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        if (hiding)
            rb.velocity = movement * moveSpeed;
        else
            rb.velocity = Vector2.zero;
    }

    private void UpdateHidingState()
    {
        if (hiding)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            rend.sortingOrder = 2;
            Debug.Log("I'm hiding");
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            rend.sortingOrder = 5;
            Debug.Log("I'm not hiding");
        }
    }

    // Trigger collider on hiding spot
    private void OnTriggrtEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HidingSpot"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HidingSpot"))
        {
            canHide = false;
            hiding = false;
            UpdateHidingState();
        }
    }

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
    }
}
