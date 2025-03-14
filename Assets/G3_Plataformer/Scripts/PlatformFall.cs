using System.Collections;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    private Rigidbody2D rb;

    // Tempo para a plataforma cair
    private float fallTime = 0.5f;

    private float destroyTime = 2f;

    // Shake
    private float shakeIntensity = 0.5f;
    private float shakeSpeed = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        Shake();
    }

    void Shake()
    {
        float shakeX = Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity;
        float shakeY = Mathf.Cos(Time.time * shakeSpeed) * shakeIntensity;

        transform.position += new Vector3(shakeX, shakeY, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallTime);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
