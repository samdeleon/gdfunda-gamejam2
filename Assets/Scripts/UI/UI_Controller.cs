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

    public static bool isPaused;
    public static bool menuToggled;


    // Start is called before the first frame update
    void Start() { 

            Pause();
        instructionsPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuToggled = !menuToggled;

            EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.TOGGLE_MENU);
            this.togglePause();
        }
    }

    // PAUSE CODE
    private void togglePause()
    {
        if (isPaused)
        {   
            Resume();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            pausedPanel.SetActive(false);
        }
        else
        {
            Pause();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            pausedPanel.SetActive(true);
        }

        isPaused = !isPaused;
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

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


            Resume();
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
