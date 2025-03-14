using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int hp = 50;
    PlayerCombat player;
    bool enemyInRange = false;
    bool hasAttacked = false;


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Detectado");
            enemyInRange = true;
            player = collision.GetComponentInChildren<PlayerCombat>();
            if(!hasAttacked && player != null)
                StartCoroutine(Attack());
            
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

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Attack()
    {
        if (enemyInRange)
        {
            animator.SetTrigger("Attack");
            player.TakeDamage(10);
            hasAttacked = true;


            yield return new WaitForSeconds(2f);

            hasAttacked = false;
        }
    }
    
    IEnumerator Death()
    {
        animator.SetTrigger("Death");

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
