using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreBeat : MonoBehaviour {

    Animator highScoreAnimator;

    private void Start()
    {
        highScoreAnimator = GetComponent<Animator>();
    }

    void HideHighScore()
    {
        highScoreAnimator.SetBool("ShowHighScore", false);
    }

    public void ShowHighScore()
    {
        highScoreAnimator.SetBool("ShowHighScore", true);
    }
}
