using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCONTROL : MonoBehaviour
{
    public float speed,jumpHeight;
    float velX, velY;
    Rigidbody2D rb;
    public Transform groundcheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
        if (isGrounded)
        {
            anim.SetBool("jump",false);
        }
        else
        {
            anim.SetBool("jump",true);
        }
        FlipCharacter();
        Attack();
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

   public void Attack()
    {
     if(Input.GetButtonDown("Fire1"))
     {
       anim.SetBool("Attack",true);
     }
     else
     {
        anim.SetBool("Attack",false);
     }
    }
   


public void Jump()
{
    if (Input.GetButtonDown("Jump") && isGrounded)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}

    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * speed, velY);

        if(rb.velocity.x != 0)
        {
            anim.SetBool("walk",true);
        }
        else
        {
           anim.SetBool("walk",false); 
        }
    }

    public void FlipCharacter()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Mira hacia la derecha
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Mira hacia la izquierda
        }
    }
}
