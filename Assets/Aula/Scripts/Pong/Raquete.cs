using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquete : MonoBehaviour
{
    
    int debuff = 3;
    int speed = 5;

    int length1 = 5;
    int length2 = 7;

    int scorePlayer1 = 10;
    int scorePlayer2 = 15;

   
    void Start()
    {
        
        int currentSpeed = speed - debuff;
        Debug.Log("O jogador 1 é muito veloz, ele teve uma nota 5/5 na última prova de velocidade. Como está chovendo, ele não pode ir com a velocidade máxima. A velocidade atual dele é: " + currentSpeed);

        int lengthDifference = length2 - length1;
        Debug.Log("O jogador 2 é maior que o jogador 1, ele tem uma vantagem de " + lengthDifference + " unidades em comparação ao jogador 1.");

        int totalScore = scorePlayer1 + scorePlayer2;
        Debug.Log("A pontuação total dos dois jogadores é: " + totalScore);
     
        bool isPlayer1Faster = currentSpeed > speed;
        Debug.Log("O jogador 1 está mais rápido que o normal? " + isPlayer1Faster);

        bool isPlayer2Taller = length2 > length1;
        Debug.Log("O jogador 2 é mais alto que o jogador 1? " + isPlayer2Taller);

        bool isScoreEqual = scorePlayer1 == scorePlayer2;
        Debug.Log("Os jogadores têm a mesma pontuação? " + isScoreEqual);

        scorePlayer1++; 
        Debug.Log("A pontuação do jogador 1 após o incremento é: " + scorePlayer1);
      
        int doubleSpeed = speed * 2;
        Debug.Log("Se o jogador 1 dobrar sua velocidade, ele terá: " + doubleSpeed);

       
    }
}