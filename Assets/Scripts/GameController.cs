using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        startTime = 120;
        inverseTime = 0;

        numTotalTreat = 10;
        numCurrentTreat = 0;
        treatCounter.text = "Found: 0 / " + numTotalTreat;

        gamePlaying = true;
        gameWin = false;
        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.RESTART, this.RestartLevel);
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

    private void RestartLevel()
    {
        startTime = 120;
        inverseTime = 0;

        numTotalTreat = 10;
        numCurrentTreat = 0;
        treatCounter.text = "Found: 0 / " + numTotalTreat;

        gamePlaying = true;
        gameWin = false;

        string minutes = ((int)startTime / 60).ToString();
        string seconds = (startTime % 60).ToString("f1");
        print("Restarted Level");
        
        timerText.text = minutes + ":" + seconds;
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
        while (inverseTime < 120)
        {
            yield return new WaitForSeconds(1f);
            inverseTime++;
        }
        gamePlaying = false;
        LostGame();
    }
}
