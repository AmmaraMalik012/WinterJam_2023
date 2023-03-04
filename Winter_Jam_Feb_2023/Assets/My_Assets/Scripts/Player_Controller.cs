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


    private bool IsGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsValue;


    // joystick lines
    public Joystick joystick;




    void Start(){
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){

        IsGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // keyboard horizontal movement
        // moveInput = Input.GetAxis("Horizontal");




        // joystick lines for horizontal movement
        moveInput = joystick.Horizontal;
        if(joystick.Horizontal >=.2f){
            // moveInput = speed;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else if(joystick.Horizontal <= -.2f){
            // moveInput = -speed;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else{
            // moveInput = 0f;   
            rb.velocity = new Vector2(moveInput * 0f, rb.velocity.y);
        }




        // Debug.Log(moveInput);
        // rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0){
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }

    void Update(){


        float verticalMove = joystick.Vertical;



        if(IsGround == true){
            extraJumps = extraJumpsValue;
        }

        // if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
        if(verticalMove >= .5f && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        // } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && IsGround == true){
        } else if(verticalMove >= .5f && extraJumps == 0 && IsGround == true){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    
}
