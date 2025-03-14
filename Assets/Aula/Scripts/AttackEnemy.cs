using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackEnemy : MonoBehaviour
{


    [SerializeField] Animator animator;
    [SerializeField]float maxHP = 50;
    [SerializeField]float currentHP;
    AttackPlayer player;
    bool enemyInRange = false;
    bool hasAttacked = false;
    [SerializeField] Image slider1;

    private void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if (enemyInRange && !hasAttacked)
        {
            Attack();
        }

        UpdateHpUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Detectado");
            enemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Fugiu");
            enemyInRange = false;
            hasAttacked = false;
        }
    }

    void Attack()
    {
        AttackPlayer playerScript = FindAnyObjectByType<AttackPlayer>();
        playerScript.TakeDamage(10);
        animator.SetTrigger("Attack");
        hasAttacked = true;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) 
        {
            animator.SetTrigger("Death");
            StopMovement();
            Destroy(transform.parent.gameObject,1f);
        }
    }

    public void StopMovement()
    {
        Rigidbody2D rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
            
    }

    void UpdateHpUI()
    {
        slider1.fillAmount = currentHP/maxHP;
    }
}
