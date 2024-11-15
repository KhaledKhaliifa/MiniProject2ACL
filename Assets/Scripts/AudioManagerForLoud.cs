using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerForLoud : MonoBehaviour
{
    public static AudioManagerForLoud Instance;
    public AudioSource audioSource;
    public AudioSource decisionSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();

        }
    }

    public void PauseMusic()
    {
        audioSource.Pause();
        decisionSource.Play();
    }

    public void ResumeMusic()
    {
        decisionSource.Stop();
        audioSource.UnPause();
    }
}
