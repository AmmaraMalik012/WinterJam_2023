using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;


    [SerializeField] private bool IsGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround, lineMask;
    [SerializeField] private int extraJumps;
    public int extraJumpsValue;
    [SerializeField] private bool overLine;

    public bool canDoubleJump;

    // joystick lines
    public Joystick joystick;


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // keyboard horizontal movement
        // moveInput = Input.GetAxis("Horizontal");


        // joystick lines for horizontal movement
        moveInput = joystick.Horizontal;
        if (joystick.Horizontal >= .2f)
        {
            // moveInput = speed;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else if (joystick.Horizontal <= -.2f)
        {
            // moveInput = -speed;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            // moveInput = 0f;   
            rb.velocity = new Vector2(moveInput * 0f, rb.velocity.y);
        }


        // Debug.Log(moveInput);
        // rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private bool inAir;

    void Update()
    {
        IsGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        overLine = Physics2D.OverlapCircle(groundCheck.position, checkRadius, lineMask);

        float verticalMove = joystick.Vertical;


        // if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
        if (verticalMove >= .5f)
        {
            Jump();
        }
        else if (verticalMove >= .5f && extraJumps == 0 && IsGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }


    void Jump()
    {
        if (IsGround || overLine)
        {
            rb.velocity = Vector2.up * jumpForce;
            canDoubleJump = true;
        }
        else if (canDoubleJump && IsGround || overLine)
        {
            rb.velocity = Vector2.up * jumpForce;
            canDoubleJump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}