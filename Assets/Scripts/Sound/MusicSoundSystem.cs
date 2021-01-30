/**
Use this helper functions:
PlayMenuMusic ()
PlayGameMusic ()
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicSoundSystem : MonoBehaviour
{
    public AudioClip[] menuAudioClips;
    public AudioClip[] gameAudioClips;

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
            Debug.Log("MusicSoundSystem: No se ha encontrado el componente AudioSource");
        }

        if (menuAudioClips == null || menuAudioClips.Length == 0) {
            Debug.Log("MusicSoundSystem: No se han configurado clips de sonido de menu");
        }
        if (gameAudioClips == null || gameAudioClips.Length == 0) {
            Debug.Log("MusicSoundSystem: No se ha encontrador clips de sonido de juego");        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void PlayRandomClip(AudioClip[] clips) {
         if (m_audioSource != null && clips != null && clips.Length > 0 ) {
            m_audioSource.clip = clips[(int)UnityEngine.Random.Range(0, clips.Length)];
            Play ();
        }
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

    
    public void PlayMenuMusic () {
        PlayRandomClip(menuAudioClips);
    }

    public void PlayGameMusic () {
        PlayRandomClip(gameAudioClips);
    }
}
