using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChanger : MonoBehaviour
{
    public Slider Master, Musica, FX;

    

    void Start()
    {
        Master.value = PlayerPrefs.GetFloat("MasterVolume");
        Musica.value = PlayerPrefs.GetFloat("MusicaVolume");
        FX.value = PlayerPrefs.GetFloat("FXVolume");
    }

    void Update()
    {
        PlayerPrefs.SetFloat("MasterVolume", Master.value);
        PlayerPrefs.SetFloat("MusicaVolume", Musica.value);
        PlayerPrefs.SetFloat("FXVolume", FX.value);
    }

    

}
