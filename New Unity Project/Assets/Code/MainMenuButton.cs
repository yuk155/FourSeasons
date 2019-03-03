using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;
    float volume;

    public void Update()
    {
        audioMixer.GetFloat("MusicVolume", out volume);
        audioSource.volume = 1 + volume / 80;
    }

    public void doExitGame()
    {
        Application.Quit();
    }

    public void goToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void goToStoryBoards()
    {
        SceneManager.LoadScene("StoryBoards");
    }

    public void goToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
