using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{
    [Header("Main Page")]
    [SerializeField] GameObject firstPanel = default;
    [SerializeField] GameObject playButton = default;

    [Header("Options Page")]
    [SerializeField] GameObject optionsPanel = default;
    [SerializeField] GameObject startButton = default;

    [Header("Actions Helpers")]
    [SerializeField] GameObject canvasinGame = default;

    private void Update() {
        if ( Input.GetButtonDown("Cancel") )
        {
            returnToMain();
        }
    }

    private void OnEnable() {
        returnToMain();
    }

    public void returnToMain(){
        firstPanel.SetActive(true);
        playButton.SetActive(true);
        optionsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void pressPlay(){
        firstPanel.SetActive(false);
        optionsPanel.SetActive(true);
        playButton.SetActive(false);
        EventSystem.current.SetSelectedGameObject(startButton);
    }

    public void StartGame(){
        optionsPanel.SetActive(false);
        gameObject.SetActive(false);
        canvasinGame.SetActive(true);
    }
}
