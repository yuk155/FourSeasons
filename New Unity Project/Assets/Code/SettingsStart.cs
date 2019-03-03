using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsStart : MonoBehaviour
{
    public AudioMixer audioMixer;
    float ExistingVolume;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.GetFloat("MusicVolume", out ExistingVolume);
        volumeSlider.value = ExistingVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
