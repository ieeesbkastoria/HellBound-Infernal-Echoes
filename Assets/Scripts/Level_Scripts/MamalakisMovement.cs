using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Add this line to include the UnityEngine.Events namespace

public class MamalakisMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float dirX;
    public int pz;

    public Animator animator;

    // Define events
    [Header("Events")]
    [Space]
    public UnityEvent onLandingEvent;

    private void Awake()
    {
        // Ensure event is initialized
        if (onLandingEvent == null)
            onLandingEvent = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(dirX));
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            animator.SetBool("IsJumping", true);
        }

        Flip123();
        pz = Posi();
    }


    private void Flip123()
    {
        if (dirX < 0f)
        {
            sprite.flipX = true;
        }

        else if (dirX > 0f)
        {
            sprite.flipX = false;
        }
    } 

    public void OnLanding()
    {
        Debug.Log("OnLanding function called.");
        animator.SetBool("IsJumping", false);
        onLandingEvent.Invoke();
    }
    
    private int Posi()
    {
        if (dirX > 0f)
        {
            return 1;
        }
        else if (dirX < 0f)
        {
            return 2;
        }
        else 
        {
            return 3;
        }
    }
}
