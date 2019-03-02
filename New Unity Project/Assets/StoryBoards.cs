using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoards : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI TextM;
    float waitTime = 2.5f;
    float counter = 0;
    int panel = 1;

    private void Start()
    {
        //TextM.alpha = 0;
    }

    private void Update()
    {
        if (Input.anyKeyDown && panel == 4)
        {
            TextM.text = "I don't want a new teddy";
            panel += 1;
            
        }
        else if (Input.anyKeyDown && panel == 3)
        {
            TextM.text = "We can buy you a new Teddy";
            panel += 1;

        }
        else if (Input.anyKeyDown && panel == 2)
        {
            TextM.text = "We Have to Go!";
            panel += 1;
        }
        else if (Input.anyKeyDown && panel == 1)
        {
            TextM.text = "I can't find Teddy";
            panel += 1;
        }
    }

    //("We can buy you a new Teddy");
    //("I don't want a new Teddy!");

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
