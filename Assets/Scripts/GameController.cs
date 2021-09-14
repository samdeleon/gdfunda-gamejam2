using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject Treat, UIContainer, gameFinishedPanel, gameOverPanel;
    public Text treatCounter, timerText, timeCounter;

    private int numTotalTreat, numCurrentTreat, inverseTime;
    private float startTime;

    public bool gamePlaying { get; private set; }
    private bool gameWin;

    private float t;

    private String savedTimeStr;

    TimeSpan timePlaying;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inverseTime = 0;

        numTotalTreat = 1;
        numCurrentTreat = 0;
        treatCounter.text = "Found: 0 / " + numTotalTreat;

        gamePlaying = false;
        gameWin = false;

        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.START_TIMER, this.StartTimer);
    }

    public void StartTimer(){
        gamePlaying = true;
        startTime = Time.time;
        UIContainer.SetActive(true);
        StartCoroutine(Begin());
    }

    private void Update()
    {
        if (gamePlaying)
        {
            t = Time.time - startTime;
            /*
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f1");
            */
            timePlaying = TimeSpan.FromSeconds(t);
            String timePlayingStr = timePlaying.ToString("m':'ss'.'f");
            //timerText.text = minutes + ":" + seconds;
            timerText.text = timePlayingStr;
            savedTimeStr = timePlayingStr;
        }
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
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
            SceneManager.LoadScene("LosingScreen");
    }

    private void EndGame()
    {
        gamePlaying = false;
        SceneManager.LoadScene("WinningScreen");
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
    public String TookTime()
    {
        Debug.Log(savedTimeStr);
        return savedTimeStr;
    }
}
