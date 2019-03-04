using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Summer1()
    {
        SceneManager.LoadScene("Summer 1");
    }

    public void Fall1()
    {
        SceneManager.LoadScene("Fall 1");
    }

    public void Winter1()
    {
        SceneManager.LoadScene("Winter 1");
    }

    public void Spring1()
    {
        SceneManager.LoadScene("Spring New1");
    }

    public void Summer2()
    {
        SceneManager.LoadScene("Summer 2");
    }

    public void Fall2()
    {
        SceneManager.LoadScene("Fall 2");
    }

    public void Winter2()
    {
        SceneManager.LoadScene("Winter 2");
    }

    public void Spring2()
    {
        SceneManager.LoadScene("Spring 2");
    }
}
