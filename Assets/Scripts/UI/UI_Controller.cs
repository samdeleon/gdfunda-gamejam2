using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Controller : MonoBehaviour
{

    [SerializeField] private GameObject interactLabel;

    //private int treatsFound = 0;


    // Start is called before the first frame update
    void Start() { 

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        
     }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
        Time.timeScale = 1f;
    }

    private void showInteractPrompt()
    {
        this.interactLabel.SetActive(true);
    }

    private void hideInteractPrompt()
    {
        this.interactLabel.SetActive(false);
    }


    private void Resume()
    {
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }

}
