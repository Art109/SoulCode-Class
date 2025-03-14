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

    Vector3 direction;
    float tempo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        direction = (pontoB.position - pontoA.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        float flutucao = Mathf.Sin(tempo) + alturaSalto;

        transform.position = new Vector3(transform.position.x , pontoA.position.y + flutucao, transform.position.z);

        tempo += Time.deltaTime * 2f;

        if (Vector2.Distance(transform.position, pontoB.position) < 1f)
        {
            direction = (pontoA.position - pontoB.position).normalized;
        }
        else if (Vector2.Distance(transform.position, pontoA.position) < 1f)
        {
            direction = (pontoB.position - pontoA.position).normalized;
        }
    }
}
