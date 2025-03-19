using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Flutuação : MonoBehaviour
{

    public Transform pontoA;
    public Transform pontoB;
    public float speed;
    public float alturaSalto;

    bool lookingRight = true;

    Animator animator;

    Vector3 direction;
    float tempo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        direction = (pontoB.position - pontoA.position).normalized;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        float flutucao = Mathf.Sin(tempo) + alturaSalto;

        transform.position = new Vector3(transform.position.x , pontoA.position.y + flutucao, transform.position.z);

        tempo += Time.deltaTime * 2f;

        if (Vector2.Distance(transform.position, pontoB.position) < 0.5f)
        {
            direction = (pontoA.position - pontoB.position).normalized;
            Flip();
        }
        else if (Vector2.Distance(transform.position, pontoA.position) < 0.5f)
        {
            direction = (pontoB.position - pontoA.position).normalized;
            Flip();
        }
    }

    void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
        }
    }
}
