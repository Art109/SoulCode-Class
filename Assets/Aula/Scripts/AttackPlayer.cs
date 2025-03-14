using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttackPlayer : MonoBehaviour
{
    
    public AttackEnemy enemyScript;
    public int hp = 100;
    [SerializeField] Image slider1;
    

    void Update()
    {
        UpdateLife();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Attack(collision.gameObject);
            Debug.Log("Achei o inimigo");
        }
    }

    public void Attack(GameObject enemy)
    {
        AttackEnemy enemyScript = enemy.GetComponentInChildren<AttackEnemy>();
        enemyScript.TakeDamage(10);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateLife()
    {
        slider1.fillAmount = hp * 0.01f;
        
    }
}
