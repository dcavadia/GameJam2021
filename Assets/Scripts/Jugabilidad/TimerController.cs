using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] TextMeshProUGUI timerText = default;
    [SerializeField] bool displayClockFormat = false;
    [SerializeField] Color32 safeColor = default;
    [SerializeField] Color32 badColor = default;

    [Header("Feature")]
    [SerializeField] float limit = 90000.0f;
    float currentTime = 0;
    bool isTicking = false;
    [SerializeField] StartMenu mainMenu = default;

    [Header("Events")]
    [SerializeField] UnityEvent startTimerEvent = default;
    [SerializeField] UnityEvent stopTimerEvent = default;
    [SerializeField] UnityEvent winGameEvent = default;

    [Header("Pause")]
    [SerializeField] PauseMenu pauseMenu = default;

    [Header("Win")]
    [SerializeField] VictoryMenu victoryMenu = default;


   // public RobotPieces robotPieces;

    // [Header("Random SetUp")]
    // [SerializeField] bool randomTime = false;
    // [SerializeField] timeRange range = default;

    private void Update() 
    {

        if ( Input.GetButtonDown("Cancel") )
        {
            isTicking = false;
            pauseMenu.PauseGame();
            return;
        }

        if ( isTicking )
        {
            currentTime -= Time.deltaTime;
            displayTime();

            if ( currentTime <= 0 )
            {
                StopTimer();
            }
        }


    }

    void displayTime()
    {
        int min = (int)Mathf.Floor(currentTime)/60;
        int sec = ((int)Mathf.Floor(currentTime) - min) % 60;

        timerText.color = currentTime <= limit* 0.3f ? badColor : safeColor;

        if ( displayClockFormat )
        {
            timerText.text = ("" + min).PadLeft(2, '0')  + " : " + ("" + sec).PadLeft(2, '0') + " s";
        }else{
            timerText.text = min  + " m " + sec + " s";
        }
         
    }

    //private void OnEnable() 
   // {
    //    StartTimer();
   // }

    public void StartTimer()
    {
        currentTime = limit;
        isTicking = true;
        startTimerEvent.Invoke();
    }

    public void StopTimer()
    {
        isTicking = false;
        gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        stopTimerEvent.Invoke();

        UnityEngine.SceneManagement.SceneManager.LoadScene("SpaceDelivery");

    }

    public void ResumeTimer()
    {
        gameObject.SetActive(true);
        isTicking = true;
    }

    public void WinGame()
    {
        isTicking = false;
        gameObject.SetActive(false);
        victoryMenu.WinGame();
        winGameEvent.Invoke();
    }
}