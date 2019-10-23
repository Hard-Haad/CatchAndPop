using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetector : MonoBehaviour {

    public SpawnManager mainSpawnManager;
    public GameManager mainGameManager;
    BoxCollider2D edgeCollider;

	void Start () {
        edgeCollider = GetComponent<BoxCollider2D>();
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EdgeObject")
        {
            mainSpawnManager.StopSpawning();
            mainGameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EdgeObject")
        {
            mainSpawnManager.StopSpawning();
            mainGameManager.GameOver();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EdgeObject")
        {
            mainSpawnManager.StopSpawning();
            mainGameManager.GameOver();
        }
    }
}
