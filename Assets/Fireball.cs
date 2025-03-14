using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]float lifeTime;
    [SerializeField] float speed;
    Animator animator;
    [SerializeField]Rigidbody2D rb;


    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Finish());
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction, Vector3 position)
    {
        transform.position = position;
        rb.velocity = direction.normalized * speed;
        if (rb != null)
            Debug.Log("ta certo o rb");
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(lifeTime);
        animator.SetTrigger("End");
        Destroy(gameObject,0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            AttackEnemy attackEnemy = collision.GetComponentInChildren<AttackEnemy>();
            if (attackEnemy != null) 
            {
                attackEnemy.TakeDamage(50);  
                
            }
            //
            animator.SetTrigger("End");
            Destroy(gameObject, 0.5f);
        }
    }
}
