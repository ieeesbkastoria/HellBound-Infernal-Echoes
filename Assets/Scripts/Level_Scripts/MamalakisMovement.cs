using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamalakisMovement : MonoBehaviour
{
   
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float dirX;
    public int pz;
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
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }

        Flip123();
        pz = Posi();
    }

    private void Flip123()
    {
        if (dirX > 0f)
        {
            sprite.flipX = true;
        }

        else if (dirX < 0f)
        {
            sprite.flipX = false;
        }
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
