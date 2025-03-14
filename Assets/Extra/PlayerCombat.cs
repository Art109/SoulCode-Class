using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public EnemyCombat enemyScript;
    public float currentHp = 100;
    public float maxHp = 100;
    [SerializeField]Collider2D attackCollider;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Attack(collision.gameObject);
            Debug.Log("Achei o inimigo");
        }
    }

    

    void Attack(GameObject enemy)
    {
            
            enemyScript = enemy.GetComponentInChildren<EnemyCombat>();
            enemyScript.TakeDamage(20);
        
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if(currentHp <= 0)
        {
            //Cena de GameOver
        }
    }

}
