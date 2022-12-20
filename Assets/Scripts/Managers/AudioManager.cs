using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] private AudioSource[] audioSource;
    public void CorrectAudio() {
        audioSource[0].Play();
    }
    
    public void WrongAudio()
    {
        audioSource[1].Play();
    }
}
