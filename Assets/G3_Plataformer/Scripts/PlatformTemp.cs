using System.Collections;
using UnityEngine;


public class PlatformTemp : MonoBehaviour
{
    private float timeVisibility = 4f;
    private float timeInvisibility = 1f;

    private SpriteRenderer sr;
    private BoxCollider2D col;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeVisibility);
            sr.enabled = false;
            col.enabled = false;

            yield return new WaitForSeconds(timeInvisibility);
            sr.enabled = true;
            col.enabled = true;

        }
    }
}
