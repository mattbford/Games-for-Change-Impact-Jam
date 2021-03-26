using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("GameScene");

    }

    public void showHowtoPlay()
    {
        SceneManager.LoadScene("HowToPlayMenu");
    }

    public void showCredits()
    {
        SceneManager.LoadScene("Credits Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
