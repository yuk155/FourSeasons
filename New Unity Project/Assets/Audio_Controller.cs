using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Controller : MonoBehaviour

{
    public AudioSource audioSource;
    public AudioMixer audioMixer;
    float volume;

    // Update is called once per frame
    void Update()
    {
        audioMixer.GetFloat("MusicVolume", out volume);
        audioSource.volume = 1 + volume / 80;
    }
}
