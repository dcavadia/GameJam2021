using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SceneManager : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public FreeLookCameraOverride freeLook;
    public CharacterMovementNoCamera characterController;
    public GameObject reticle;
    public GameObject menu;
    public GameObject transitionCamera;

    public Asteroid asteroid;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    IEnumerator ActivatePlayerController()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(6);
        transitionCamera.SetActive(false);
        characterController.enabled = true;
        reticle.SetActive(true);
    }
}
