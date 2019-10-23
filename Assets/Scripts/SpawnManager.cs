using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    float spawnTime;
    bool startSpawning;

    public float amountAddedToSpawnDelay;
    public float spawnDelay;
    public float spawnDelayDegradation;
    public ColorSpawner[] colorSpawners;

	void Start () {
        spawnTime = 0f;
        startSpawning = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (startSpawning)
        {
            if (spawnTime < Time.time)
            {
                SpawnColor();
                spawnTime = Time.time + spawnDelay;
                spawnDelay -= spawnDelayDegradation;
                spawnDelay = Mathf.Clamp(spawnDelay, 0.3f, 2f);
            }
        }
	}

    void SpawnColor()
    {
        int _randomSpawnIndex = Random.Range(0, colorSpawners.Length);
        colorSpawners[_randomSpawnIndex].SpawnColor();
    }

    public void StartSpawning() {
        startSpawning = true;
    }

    public void StopSpawning()
    {
        startSpawning = false;
    }

    public void AddToSpawnDelay()
    {
        spawnDelay += amountAddedToSpawnDelay;
    }
}
