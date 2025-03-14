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
        Debug.Log("O jogador 1 � muito veloz, ele teve uma nota 5/5 na �ltima prova de velocidade. Como est� chovendo, ele n�o pode ir com a velocidade m�xima. A velocidade atual dele �: " + currentSpeed);

        int lengthDifference = length2 - length1;
        Debug.Log("O jogador 2 � maior que o jogador 1, ele tem uma vantagem de " + lengthDifference + " unidades em compara��o ao jogador 1.");

        int totalScore = scorePlayer1 + scorePlayer2;
        Debug.Log("A pontua��o total dos dois jogadores �: " + totalScore);
     
        bool isPlayer1Faster = currentSpeed > speed;
        Debug.Log("O jogador 1 est� mais r�pido que o normal? " + isPlayer1Faster);

        bool isPlayer2Taller = length2 > length1;
        Debug.Log("O jogador 2 � mais alto que o jogador 1? " + isPlayer2Taller);

        bool isScoreEqual = scorePlayer1 == scorePlayer2;
        Debug.Log("Os jogadores t�m a mesma pontua��o? " + isScoreEqual);

        scorePlayer1++; 
        Debug.Log("A pontua��o do jogador 1 ap�s o incremento �: " + scorePlayer1);
      
        int doubleSpeed = speed * 2;
        Debug.Log("Se o jogador 1 dobrar sua velocidade, ele ter�: " + doubleSpeed);

       
    }
}