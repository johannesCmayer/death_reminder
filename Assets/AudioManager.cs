using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip gong;
    AudioSource myAudioSource;

    void Awake()
    {
        instance = this;
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayGong()
    {
        myAudioSource.Play();
    }
}
