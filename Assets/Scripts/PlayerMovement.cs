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

        // When the player presses E, they will hide behind object
        if (canHide && Input.GetKeyDown(KeyCode.E))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            rend.sortingOrder = 2;
            hiding = true;
            Debug.Log("I'm hiding");

        }
        // Player isn't hiding and didn't press E
        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            rend.sortingOrder = 5;
            hiding = false;
            Debug.Log("I'm am not hiding");
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
        }
    }
}
