using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryBoards : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI TextM;
    float waitTime = 2.5f;
    float counter = 0;
    int panel = 1;
    Color child = new Color(0.035f, 0.608f, 0.678f);
    Color parent = new Color(0.039f, 0.478f, 0.063f);
    public AudioClip AClip;
    public AudioSource ASource;
    public int childfont = 30;
    public int childsadfont = 24;
    public int parentfont = 36;
    public AudioMixer audioMixer;

    private void Start()
    {
        //TextM.alpha = 0;
    }

    private void Update()
    {
        
        if (Input.anyKeyDown && panel == 5)
        {
            float musicVolume;
            audioMixer.GetFloat("MusicVolume", out musicVolume);
            Debug.Log(musicVolume);
            Debug.Log(1+(musicVolume/80));
            ASource.volume = 1+(musicVolume/80);
            ASource.clip = AClip;
            ASource.Play();
            //Play the first scene
            //SceneManager.LoadScene();
            panel += 1;
        }
        else if (Input.anyKeyDown && panel == 4)
        {
            TextM.color = child;
            TextM.fontSize = childsadfont;
            TextM.text = "I don't want a new teddy";
            panel += 1;

        }
        else if (Input.anyKeyDown && panel == 3)
        {
            TextM.color = parent;
            TextM.fontSize = parentfont;
            TextM.text = "We can buy you a new Teddy";
            panel += 1;

        }
        else if (Input.anyKeyDown && panel == 2)
        {
            TextM.color = parent;
            TextM.fontSize = parentfont;
            TextM.text = "We have to Go!";
            panel += 1;
        }
        else if (Input.anyKeyDown && panel == 1)
        {
            TextM.color = child;
            TextM.fontSize = childfont;
            TextM.text = "I can't find Teddy";
            panel += 1;
        }
    }

    private void FadeInOut(string PrintText)
    {
        Debug.Log(TextM.alpha);
        if (TextM.alpha == 0.0)
        {
        TextM.CrossFadeAlpha(1.0f, 2.5f, false);
        }
        if (TextM.alpha == 1)
        {
            TextM.CrossFadeAlpha(0.0f, waitTime, false);
        }    
    }

    private void timer()
    {
        counter = 0;
        while (counter < waitTime)
        {
            counter += Time.deltaTime;
            Debug.Log("We have waited for: " + counter + " seconds");
        }
        
    }

}
