using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpawner : MonoBehaviour {

    public ColorPalleteManager colorPalleteManager;
	public GameObject colorPrefab;
	public int numberOfColors;
    float sizeReductionPercent;

	void Start () {
		//InvokeRepeating("SpawnColor",0f, Random.Range(4,10));
	}

    Vector3 GetRandomSpawnPoint() {
        Vector3 transformPoint = Vector3.zero;
        if(transform.position.x > 9)
        {
            transformPoint = new Vector3(transform.position.x, Random.Range(-5, 5), transform.position.z);
        }else if(transform.position.x < -9)
        {
            transformPoint = new Vector3(transform.position.x, Random.Range(-5, 5), transform.position.z);
        }else if(transform.position.y > 5)
        {
            transformPoint = new Vector3(Random.Range(-9, 9), transform.position.y, transform.position.z);
        }
        else if (transform.position.y < -5)
        {
            transformPoint = new Vector3(Random.Range(-9, 9), transform.position.y, transform.position.z);
        }

        return transformPoint;
    }

	public void SpawnColor(){
		GameObject colorInstance = (GameObject)Instantiate(colorPrefab, GetRandomSpawnPoint(), Quaternion.Euler(transform.forward));
        colorInstance.transform.localScale = new Vector3(colorInstance.transform.localScale.x - sizeReductionPercent, colorInstance.transform.localScale.y - sizeReductionPercent, colorInstance.transform.localScale.z);
        Color _randomColor = colorPalleteManager.GetRandomColor();
        colorInstance.GetComponent<ColorObjectController>().SetColor(_randomColor);
	}

}
