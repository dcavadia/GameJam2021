using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SceneManager : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public FreeLookCameraOverride freeLook;
    public RobotCharacterMovementNoCamera characterController;
    public GameObject reticle;
    public GameObject menu;
    public GameObject transitionCamera;

    public Asteroid asteroid; 
    public StarShip starShip;

    public Animator anim;

    MusicSoundSystem m_musicSoundSystem = null;
    // Start is called before the first frame update
    void Start()
    {
        m_musicSoundSystem = GetComponentInChildren<MusicSoundSystem>();

        if (m_musicSoundSystem == null) {
            Debug.Log("SceneManager: No se encontro el componente MusicSoundSystem");
        }
        else {
            m_musicSoundSystem.PlayMenuMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        playableDirector.Play();
        freeLook.enabled = true;
        menu.SetActive(false);
        asteroid.AddInitialForce();
        StartCoroutine(ActivatePlayerController());
        //anim.SetBool("IdleHead", true);
        //anim.SetBool("WalkHead", false);
        //reticle.active = true;
        if (m_musicSoundSystem != null)
            m_musicSoundSystem.PlayGameMusic();
    }

    IEnumerator ActivatePlayerController()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(6);
        transitionCamera.SetActive(false);
        characterController.enabled = true;
        reticle.SetActive(true);

        if (m_musicSoundSystem != null)
            starShip.OnCameraEnter();
    }
}
