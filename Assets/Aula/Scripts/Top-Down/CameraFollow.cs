using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTranform;
    [SerializeField] float cameraSpeed;
    Vector3 vel = Vector3.zero;


    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }

    

    void FollowPlayer()
    {
        if (playerTranform != null)
        {
            Vector3 targetPosition = playerTranform.position;
            targetPosition.z = transform.position.z;
 
            
            transform.position =  Vector3.Lerp(transform.position, targetPosition, cameraSpeed);
            

        }
    }
    
}
