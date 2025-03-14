using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // ATENÇÃO: Esse script requer 2 COLLIDERS
    // Apenas aplique 2 colliders idênticos, mas ativa a caixa de Trigger em um deles.

    public Transform pointA; // Lembrar de colocar Ponto A e Ponto B
    public Transform pointB;
    private float velocity = 3f;
    private bool movingToB = true;
    private bool srFlip = true;
    private Vector3 direction;

    // Caso não precise que objeto vire quando bata em um ponto pode tirar a função Flip()
    private SpriteRenderer sr;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        direction = (pointB.position - pointA.position).normalized;
    }

    void Update()
    {
        transform.position += direction * velocity * Time.deltaTime;

        if (Vector2.Distance(transform.position, pointB.position) < 1f && movingToB)
        {
            movingToB = false;
            direction = (pointA.position - pointB.position).normalized;
            Flip();
        }
        else if (Vector2.Distance(transform.position, pointA.position) < 1f && !movingToB)
        {
            movingToB = true;
            direction = (pointB.position - pointA.position).normalized;
            Flip();
        }
    }

    void Flip()
    {
        sr.flipX = srFlip;
        srFlip = !srFlip;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}


