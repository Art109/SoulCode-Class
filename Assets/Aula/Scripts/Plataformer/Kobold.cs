using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Kobold : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    float speed = 1;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Flip();

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position,0.2f);
    }

    void Movement()
    {
       
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (rb.velocity != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else 
        {
            animator.SetBool("isWalking", false);
        }

    }

    void Flip()
    {
    
        bool inBorder = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (!inBorder)
        {
            speed *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            
        }
    }
}
