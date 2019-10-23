using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public Text highScoreText;
    public Animator startAnimator;

    public void DisplayHighScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void Retry()
    {
        UseStartAnimations();
        Invoke("ChangeSceneToGame", 1f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        UseStartAnimations();
        Invoke("ChangeSceneToMainMenu", 1f);
    }

    void ChangeSceneToGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    void ChangeSceneToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    void UseStartAnimations()
    {
        startAnimator.SetBool("Open", false);
    }


}
