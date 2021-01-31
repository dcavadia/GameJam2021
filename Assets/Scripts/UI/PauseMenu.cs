using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject resumeButton = default;
    [SerializeField] TimerController timer = default;
    [SerializeField] GameObject creditsCanvas = default;
    [SerializeField] List<buttonAnimations> buttons = new List<buttonAnimations>();
    private void Update() 
    {
        if ( Input.GetButtonDown("Cancel") )
        {
            ResumeGame();
        }
        // if ( gameObject.activeInHierarchy && !EventSystem.current.currentSelectedGameObject )
        // {
        //     EventSystem.current.SetSelectedGameObject(resumeButton);
        // }
    }

    public void PauseGame()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        timer.ResumeTimer();
        creditsCanvas.SetActive(false);
        buttons.ForEach( button => button.onDeselect());
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void FinishSession()
    {
        ResumeGame();
        timer.StopTimer();
    }
}
