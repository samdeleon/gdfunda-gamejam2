using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosingScreen : MonoBehaviour
{
    [SerializeField] public GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Lose);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTheGame()
    {
        Application.Quit();
    }

    public void TryAgain(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ShowCredits() {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits() {
        creditsPanel.SetActive(false);
    }

}
