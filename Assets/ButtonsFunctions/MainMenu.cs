using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(0);

    }

    public void showHowtoPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void showCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
