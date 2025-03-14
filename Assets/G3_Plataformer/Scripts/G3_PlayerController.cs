using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class G3_PlayerController : MonoBehaviour
{

    //Singleton
    public static G3_PlayerController Instance;

    [Header("Horizontal Movement Settings")]
    [SerializeField]float moveSpeed = 2;
    float direction = 1;

    [Header("Vertical Movement Settings")]
    [SerializeField] float jumpForce;

    [Header("Dash Settings")]
    bool isDashing = false;
    bool canDash = true;
    [SerializeField]float dashDuration;
    [SerializeField]float dashCooldown;
    [SerializeField] float dashSpeed;

    [Header("Ground Check Settings")]
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask groundLayer;
    [Space(5)]


    public bool gameCompleted = false;


    Rigidbody2D rb;
    Animator animator;



    bool isWalking = false;
    bool isGrounded = false;



    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.Instance.gameFinished)
        {
            DashTrigger();
            if (isDashing) return;
            Movement();
            Jump();
            Grounded();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        
        
      
    }

    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveSpeed * moveX, rb.velocity.y);

        if (moveX != 0)
        {
            isWalking = true;
            Flip();
        }
        else
        {
            isWalking = false;
        }

        animator.SetBool("isWalking", isWalking);
    }

    void Jump()
    {

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        animator.SetBool("isJumping", !isGrounded);
    }

    void DashTrigger()
    {
        if(Input.GetKeyDown(KeyCode.F) && canDash && isGrounded)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        animator.SetTrigger("Dash");

        rb.velocity = new Vector2(dashSpeed * direction, jumpForce);

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;

    }

    void Flip()
    {
        float newDirection = Input.GetAxisRaw("Horizontal");

        if (direction != newDirection && newDirection != 0)
        {
            direction = newDirection;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    void Grounded()
    {
        isGrounded = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, 1f, groundLayer)
            ||Physics2D.Raycast(groundCheckPoint.position + new Vector3(-0.3f, 0, 0), Vector2.down, 1f, groundLayer)
            ||Physics2D.Raycast(groundCheckPoint.position + new Vector3(0.3f,0,0), Vector2.down, 1f, groundLayer);
    }
}
