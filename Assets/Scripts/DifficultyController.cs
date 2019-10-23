using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour {

    public RotationController mainRotationController;
    public ColorSpawner[] mainColorSpawner;
    public Animator colorChangeAnimator;

    SpawnManager mainSpawnManager;
    ColorPalleteManager mainColorPalleteManager;
    ScoreManager mainScoreManager;
    int prevScoreStringLength;
    int currentScoreStringLength;
    int scoreDifference;

	void Start () {
        mainScoreManager = GetComponent<ScoreManager>();
        mainColorPalleteManager = GetComponent<ColorPalleteManager>();
        mainSpawnManager = GetComponent<SpawnManager>();
        prevScoreStringLength = 0;
        scoreDifference = 0;
        currentScoreStringLength = 0;
	}
	
	void FixedUpdate () {
        if (CheckScoreDifference())
        {
            DifficultyOnScore();

        }
    }

    bool CheckScoreDifference()
    {
        int _scoreDifference = mainScoreManager.GetScore() - scoreDifference;
        if (_scoreDifference >= 10)
        {
            scoreDifference = mainScoreManager.GetScore();
            return true;
        }
        else
        {
            return false;
        }
    }

    void DifficultyOnScore()
    {
        mainSpawnManager.AddToSpawnDelay();
        mainColorPalleteManager.ChangeColors();
        colorChangeAnimator.SetBool("ColorChange", true);
        prevScoreStringLength = currentScoreStringLength;
    }

    public void RevertColorChange()
    {
        colorChangeAnimator.SetBool("ColorChange", false);
    }

}
