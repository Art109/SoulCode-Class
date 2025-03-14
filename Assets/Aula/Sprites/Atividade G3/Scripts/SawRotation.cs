using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5;
    

   
    void Update()
    {
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
}
