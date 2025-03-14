using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayer;


    private void Update()
    {
        Damage();
    }

    void Damage()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        if (enemys.Length > 0)
        {
            foreach (var enemy in enemys)
            {
                if (enemy != null)
                {
                    EnemyG3 inimigo = enemy.GetComponent<EnemyG3>();
                    if (inimigo != null)
                    {
                        Debug.Log("Causei Dano");
                        inimigo.TakeDamage();
                    }
                }
            }
        }
    }

    void Rotation()
    {
        //transform.rotation += new Vector3(1, 1, 1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
