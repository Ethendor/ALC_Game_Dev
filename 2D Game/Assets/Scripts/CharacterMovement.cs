using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    // Player Movement Variable
    public float MoveSpeed;
    public float JumpHeight;
    private bool doubleJump;

    // Player Grounded Variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    //Non-Stick Player
    private float moveVelocity;


    public Animator animator;

    // Use this for initialization
    void Start() {
    // Animation Reset
    animator.SetBool("IsWalking",false);
    animator.SetBool("IsJumping",false);
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    // Update is called once per frame
    void Update()
    {

        // This code makes the character jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();   
        }

        // Double Jump code
        if (grounded){
            doubleJump = false;
            animator.SetBool("IsJumping", false);
            }

        if(Input.GetKeyDown (KeyCode.Space)&& !doubleJump && !grounded){
            Jump();
            doubleJump = true;
        }

        // This code makes the character move from side to side using the A & D keys
        if (Input.GetKey (KeyCode.D)){
            //  GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = MoveSpeed;
            animator.SetBool("IsWalking",true);
        }
        
        else if (Input.GetKeyUp (KeyCode.D)){
            animator.SetBool("IsWalking",false);
            }


        if(Input.GetKey (KeyCode.A)){
            //  GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -MoveSpeed;
            animator.SetBool("IsWalking",true);
        }
        
        else if (Input.GetKeyUp (KeyCode.A)){
            animator.SetBool("IsWalking",false);
            }


        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        
        // Player flip
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
            
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale =new Vector3(-1f, 1f, 1f);

        //Non-Stick Player
        moveVelocity = 0f;

    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        animator.SetBool("IsJumping", true);
    }


}
