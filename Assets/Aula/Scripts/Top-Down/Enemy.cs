using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    Animator animator;
    public List<Transform> wayPoints;
    public float speed;
    int proximoPonto = 0;

    [SerializeField] GameObject torch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (wayPoints.Count > 0 && wayPoints[proximoPonto] != null)
        {
            Vector2 direction = (wayPoints[proximoPonto].position - transform.position).normalized;
            rb.velocity = direction * speed;

            animator.SetFloat("EixoX", direction.x);
            animator.SetFloat("EixoY", direction.y);

            if (Vector2.Distance(transform.position, wayPoints[proximoPonto].position) < 1f)
            {
                proximoPonto = (proximoPonto + 1) % wayPoints.Count;
            }
        }

        if (DayCycle.Instance.DayState == DayState.Night)
        {
            if (!torch.activeInHierarchy)
            {
                torch.SetActive(true);
            }
        }
        else 
        {
            if (torch.activeInHierarchy)
            {
                torch.SetActive(false);
            }
        }
    }

    
}
