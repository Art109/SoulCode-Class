using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pong : MonoBehaviour
{
   
    [SerializeField]Rigidbody2D rb;
    void Start()
    {
        rb.velocity = new Vector2(5,5);
    }

}
