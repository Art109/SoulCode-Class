using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerPlataformer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float baseSpeed = 5f;
    float playerSpeed;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform floor;
    [SerializeField] LayerMask floorLayer;
    bool isGrounded = true;
    float direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = baseSpeed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRunning",false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        IsGrounded();
        Jump();
        Flip();
        
    }


    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * playerSpeed, rb.velocity.y);

        bool isWalking = Mathf.Abs(inputX) > 0.1f;


        bool isRunning;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 10;
            isRunning = true;
        }
        else
        {
            playerSpeed = baseSpeed;
            isRunning = false;
        }


        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);


    }


    void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else if (isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }

    void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(floor.position, 0.5f, floorLayer);

        if (isGrounded) 
        {
            animator.SetBool("isJumping", false);
        }
    }

    void Flip()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if (direction != 0)
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
    }

 

}
