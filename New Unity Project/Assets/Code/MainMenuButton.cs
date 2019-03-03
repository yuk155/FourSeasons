using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
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
