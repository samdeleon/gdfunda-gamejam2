using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{

    [SerializeField] public GameObject interactLabel;


    [SerializeField] public GameObject inGamePanel;         // TODO - when combining cho's and my UI panels
    [SerializeField] public GameObject instructionsPanel;
    [SerializeField] public GameObject pausedPanel;

    //public int treatsFound = 0;


    // Start is called before the first frame update
    void Start() { 
        instructionsPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MoveScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    // pressing START after viewing instructions panel
    public void yesInstructions() { 
        instructionsPanel.SetActive(false);

        // TODO - should show the in-game panel here 
        // inGamePanel.SetActive(true);
    }

    public void Awake()
    {
        
    }

    public void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
        Time.timeScale = 1f;
    }

    public void showInteractPrompt()
    {
        this.interactLabel.SetActive(true);
    }

    public void hideInteractPrompt()
    {
        this.interactLabel.SetActive(false);
    }


    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

}
