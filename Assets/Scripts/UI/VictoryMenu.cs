using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VictoryMenu : MonoBehaviour
{
    [SerializeField] GameObject creditsButton = default;
    [SerializeField] GameObject creditsCanvas = default;
    [SerializeField] GameObject mainMenu = default;


    private void Update() {
        if ( Input.GetButtonDown("Cancel") )
        {
            backToMain();
        }
    }

    public void WinGame()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    public void backToMain()
    {
        gameObject.SetActive(false);
        creditsCanvas.SetActive(false);
        mainMenu.SetActive(true);
    }

}
