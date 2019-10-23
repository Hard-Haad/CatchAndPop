using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour {

    public Animator startAnimator;
    public Text highScoreText;

    void Start()
    {
        DisplayHighScore();
        startAnimator.SetBool("Open", true);
    }

    public void StartGame()
    {
        UseStartAnimations();
        Invoke("ChangeScene", 1f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void ChangeScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    void UseStartAnimations()
    {
        startAnimator.SetBool("Open", false);
    }

    void DisplayHighScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }


}
