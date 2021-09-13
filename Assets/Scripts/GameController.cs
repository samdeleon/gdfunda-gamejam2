using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject Treat, UIContainer, gameFinishedPanel, gameOverPanel;
    public Text treatCounter, timerText;

    private int numTotalTreat, numCurrentTreat;
    private float startTime;

    public bool gamePlaying { get; private set; }

    //TimeSpan timePlaying;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startTime = 120;

        numTotalTreat = 10;
        numCurrentTreat = 0;
        treatCounter.text = "Found: 0 / " + numTotalTreat;

        gamePlaying = true;
    }

    private void Update()
    {
        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        timerText.text = minutes + ":" + seconds;

        if(t <= 0)
        {
            Debug.Log("00000000000000");
            LostGame();
        }
    }

    public void GetTreat()
    {
        numCurrentTreat++;

        string treatCounterStr = "Found: " + numCurrentTreat + " / " + numTotalTreat;
        treatCounter.text = treatCounterStr;

        if(numCurrentTreat >= numTotalTreat)
        {
            EndGame();
        }
    }

    private void LostGame()
    {
        gamePlaying = false;
        Invoke("ShowGameOverScreen", 1.25f);
    }

    private void EndGame()
    {
        gamePlaying = false;
        Invoke("ShowGameFinishedScreen", 1.25f);
    }

    private void ShowGameFinishedScreen()
    {
        gameFinishedPanel.SetActive(true);
        UIContainer.SetActive(false);
    }

    private void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
        UIContainer.SetActive(false);
    }
}
