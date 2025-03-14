using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerG3 : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    Rigidbody2D rb;
    Animator animator;
    bool isWalking = false;

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
    }

    void Movement()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(moveX, moveY, 0) * playerSpeed;

        if (moveX != 0 || moveY != 0)
        {

            animator.SetFloat("EixoX", moveX);
            animator.SetFloat("EixoY", moveY);
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        animator.SetBool("isWalking", isWalking);


    }
}
