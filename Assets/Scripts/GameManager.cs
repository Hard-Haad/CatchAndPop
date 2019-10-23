using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Animator startAnimator;
    public GameObject gameOverScreen;

    GameOverMenu mainGameOverMenu;

    void Start()
    {
        mainGameOverMenu = GetComponent<GameOverMenu>();
        startAnimator.SetBool("OpenComplete", true);
    }

    public void GameOver()
    {
        OnGameEnd();
        Invoke("CloseWallAnimation",1f);
        Invoke("OpenWallAnimationPart", 2f);
        Invoke("ShowGameOverScreen", 2f);
    }

    void CloseWallAnimation()
    {
        startAnimator.SetBool("OpenComplete", false);
        startAnimator.SetBool("Open", false);
    }

    void OpenWallAnimationPart()
    {
        startAnimator.SetBool("Open", true);
    }

    void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        mainGameOverMenu.DisplayHighScore();
    }

    void OnGameEnd()
    {
        StartCoroutine("PopAllColors");
    }

    IEnumerator PopAllColors()
    {
        foreach (ColorObjectController child in FindObjectsOfType<ColorObjectController>())
        {
            child.OnGameEndEffects();
            Destroy(child.gameObject);
            yield return new WaitForSeconds(0.1f);

        }

    }
}
