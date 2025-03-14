using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyG3 : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        animator.SetBool("Death", true);

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
