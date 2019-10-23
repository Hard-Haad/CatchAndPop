using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Animator scoreAnimator;
    public HighScoreBeat mainHighScoreBeat;

    [SerializeField]
    int totalScore;

    int highScore;
    bool highScoreSet;

    void Start () {
        totalScore = 0;
        scoreText.text = "Pops: " + totalScore;
        highScore = PlayerPrefs.GetInt("HighScore");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseScore() {
        totalScore+=1;
        AnimateScoreTextIncrease();
        UpdateScoreTextOnPop(totalScore);

        if(totalScore > highScore)
        {
            HighScoreBeaten();
            if (!highScoreSet)
            {
                mainHighScoreBeat.ShowHighScore();
                highScoreSet = true;
            }
        }
    }

    public int GetScore()
    {
        return totalScore;
    }

    void HighScoreBeaten()
    {
        PlayerPrefs.SetInt("HighScore", totalScore);
    }

    void AnimateScoreTextIncrease() {
        scoreAnimator.SetBool("scoreUp", true);
        Invoke("SetScoreAnimatorToFalse", 0.1f);
    }

    void SetScoreAnimatorToFalse()
    {
        scoreAnimator.SetBool("scoreUp", false);
    }

    void UpdateScoreTextOnPop(int _totalScore) {
        scoreText.text = "Pops:" + _totalScore;
    }
}
