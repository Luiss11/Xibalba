using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    Animator anim;

    public bool isStatic;
    public bool isWalker;
    public bool walksRight;

    public Transform WalkCheck,PitCheck, groundCheck;
    public bool WalkDetected, PitDetected, isGrounded;
    public float detectionRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PitDetected = !Physics2D.OverlapCircle(PitCheck.position, detectionRadius, whatIsGround);
        WalkDetected = Physics2D.OverlapCircle(PitCheck.position, detectionRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);
        if((PitDetected || WalkDetected) && isGrounded)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (isStatic)
        {
            anim.SetBool("Idie", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            if (!walksRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y); // Faltaban punto y coma (;) al final de las líneas.
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y); // Faltaban punto y coma (;) al final de las líneas.
            }
        }
    }
    public void Flip()
    {
        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1,transform.localScale.y);
    }
}
