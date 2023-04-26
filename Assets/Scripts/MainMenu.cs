using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Levels");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Levels");
    }

    public void readInstrustions()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
