using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] float time = 300;
    [SerializeField] TextMeshProUGUI timeText;
    bool isCountingTime = true;

    public Transform lastCheckpoint;

    public int playerPoints = 20;

    [SerializeField] GameObject GameOverBox;
    [SerializeField] TextMeshProUGUI gameResultText;
    [SerializeField] GameObject TimerWindow;

    public bool gameFinished = false;

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }


    void Timer()
    {
        if (isCountingTime)
        {
            time -= Time.deltaTime;
            timeText.text = Mathf.FloorToInt(time).ToString();
            playerPoints = Mathf.FloorToInt(time);
            if (time <= 0)
            {
                isCountingTime = false;
                time = 0;
                EndGame();
            }
        }

    }

    public void EndGame()
    {
        isCountingTime = false ;
        gameFinished = true ;
        

        if (G3_PlayerController.Instance.gameCompleted)
        {
            gameResultText.text = "You win!";
        }
        else 
        {
            gameResultText.text = "You lose!";
            playerPoints = 0;
        }


        GameOverBox.SetActive(true);
        TimerWindow.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(2);
    }
}
