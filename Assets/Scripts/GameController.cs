using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject Treat, UIContainer, gameFinishedPanel, gameOverPanel;
    public Text treatCounter, timerText;

    private int numTotalTreat, numCurrentTreat, inverseTime;
    private float startTime;

    public bool gamePlaying { get; private set; }
    private bool gameWin;

    //TimeSpan timePlaying;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startTime = 10;
        inverseTime = 0;

        numTotalTreat = 1;
        numCurrentTreat = 0;
        treatCounter.text = "Found: 0 / " + numTotalTreat;

        gamePlaying = true;
        gameWin = false;
        StartCoroutine(Begin());
    }

    private void Update()
    {
        if (gamePlaying)
        {
            float t = startTime - Time.time;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f1");

            timerText.text = minutes + ":" + seconds;
        }
    }

    public void GetTreat()
    {
        numCurrentTreat++;
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Eat);
        string treatCounterStr = "Found: " + numCurrentTreat + " / " + numTotalTreat;
        treatCounter.text = treatCounterStr;


        if(numCurrentTreat >= numTotalTreat)
        {
            gameWin = true;
            EndGame();
        }
    }

    private void LostGame()
    {
        if (gameWin)
        {

        }
        else
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
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Win);
    }

    private void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
        UIContainer.SetActive(false);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Lose);
    }
    IEnumerator Begin()
    {
        while (inverseTime < 10)
        {
            yield return new WaitForSeconds(1f);
            inverseTime++;
        }
        gamePlaying = false;
        LostGame();
    }
}
