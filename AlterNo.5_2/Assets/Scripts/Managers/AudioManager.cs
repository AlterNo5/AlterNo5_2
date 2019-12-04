using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
    public AudioMixer mixer;

    void Start()
    {
        
    }

    public void ChangeMasterVolume(float MasterLevel)
    {
        mixer.SetFloat("Master", MasterLevel);
    }

    public void ChangeMusicVolume(float MusicLevel)
    {
        mixer.SetFloat("Music", MusicLevel);
    }

    public void ChangeFXVolume(float FXLevel)
    {
        mixer.SetFloat("FX", FXLevel);
    }
    void Update()
    {
        
    }
}
