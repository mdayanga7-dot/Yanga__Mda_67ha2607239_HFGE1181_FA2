using System;
using UnityEngine;

public class UpdatedPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Animator anim;
    private float moveInputX;
    private float moveInputY;
    private bool onJumpPad = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
       
        if (moveInputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("isMoving", true);
        }
        else if (moveInputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (isGrounded)
        {
            anim.SetBool("isGrounded", true);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }
       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (onJumpPad)
        {
            
           
        }
        else
        {
            rb.linearVelocity = new Vector2( moveInputX * moveSpeed, rb.linearVelocity.y);
        }
    }

    public void HurtTrigger()
    {
        anim.SetTrigger("Hurt");
    }

    public void SetJumpPadStatus(bool currentState)
    {
        onJumpPad = currentState;
    }
   
}
