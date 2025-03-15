using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]float playerSpeed;
    Rigidbody2D rb;
    Animator animator;
    bool isWalking = false;
    [SerializeField] AudioSource attackSound;
    [SerializeField] AudioSource stepSound;

    [Header("Magic Settings")]
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float maxMp;
    float currentMp;
    [SerializeField] Image mpBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentMp = maxMp;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        Magic();
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
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            }
        }
        else 
        {
            if (stepSound.isPlaying)
            {
                stepSound.Stop();
            }
            isWalking = false;
        }

        animator.SetBool("isWalking", isWalking);


    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Attack
            animator.SetTrigger("Attack");
            attackSound.Play();
        }
    }

    void Magic()
    {
        if (Input.GetButtonDown("Fire2") && currentMp > 30)
        {
            animator.SetTrigger("Magic");

            // Instancia a Fireball no FirePoint
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

            // Determina a direção com base no movimento atual do jogador
            Vector2 direction = new Vector2(animator.GetFloat("EixoX"), animator.GetFloat("EixoY"));
            if (direction == Vector2.zero)
                direction = Vector2.down; 

            // Dispara a Fireball
           
            fireball.GetComponent<Fireball>().Shoot(direction, firePoint.position);

            currentMp -= 30;
            UpdateMpUI();
            
        }
    }

    void UpdateMpUI()
    {
        mpBar.fillAmount = currentMp/maxMp;
    }
}
