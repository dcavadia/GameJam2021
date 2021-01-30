/**
Use:

SfxSoundSystem sfxSoundSystem = GetComponent<SfxSoundSystem>();
sfxSoundSystem.PlayRandomClip(sfxSoundSystem.coinClips);
sfxSoundSystem.PlayRandomClip(sfxSoundSystem.doorOpenClips);


*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxSoundSystem : MonoBehaviour
{
    public AudioClip[] shipAlarmClips;
    public AudioClip[] fallingBoxClips;
    public AudioClip[] coinClips;
    public AudioClip[] placingObjectClips;
    public AudioClip[] staticNoiseClips;
    public AudioClip[] explosionClips;
    public AudioClip[] screamClips;
    public AudioClip[] jumpClips;
    public AudioClip[] walkClips;
    public AudioClip[] powerUpClips;
    public AudioClip[] doorOpenClips;
    public AudioClip[] grabPieceClips;
    public AudioClip[] fallClips;
    public AudioClip[] spaceAtmosphereClips;
    public AudioClip[] introClips;
    public AudioClip[] vibrationClips;
    public AudioClip[] uiSfx1Clips;
    public AudioClip[] uiSfx2Clips;
    public AudioClip[] uiSfx3Clips;
    public AudioClip[] uiSfx4Clips;
    public AudioClip[] uiSfx5Clips;

    AudioSource m_audioSource;

    public bool IsPlaying {
        get {
            return (m_audioSource != null && m_audioSource.isPlaying);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();

        if (m_audioSource == null) {
            Debug.Log("SfxSoundSystem: No se ha encontrado el componente AudioSource");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayRandomClip(AudioClip[] clips) {
        if (m_audioSource == null) {
            Debug.Log("SfxSoundSystem: No se ha encontrado el componente AudioSource");
            return;
        }
        if (clips == null || clips.Length == 0) {
            Debug.Log("SfxSoundSystem: No se han configurado clips de sonido d");
            return;
        }
        m_audioSource.clip = clips[(int)UnityEngine.Random.Range(0, clips.Length)];
        Play ();
    }

    public void Play () {
        if (m_audioSource != null) {
            m_audioSource.Play();
        }
    }

    public void Stop () {
        if (m_audioSource != null) {
            m_audioSource.Stop();
        }
    }

}