using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            G3_PlayerController.Instance.gameCompleted = true;
            GameManager.Instance.EndGame();
        }
    }
}
