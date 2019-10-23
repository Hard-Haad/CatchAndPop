using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObjectController : MonoBehaviour {
	
	public List<GameObject> childrenList;
    public GameObject popEffectPrefab;
    public float speed;

	[SerializeField]
	public bool inContact;
	Vector3 directionVector;
	Transform target;
	SpriteRenderer colorSpriteRenderer;
    ScoreManager scoreManager;
    SoundController mainSoundController;
    GameObject mainCircle;

	void Awake(){
        colorSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	void Start () {
        scoreManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<ScoreManager>();
        mainSoundController = GameObject.FindGameObjectWithTag("Managers").GetComponent<SoundController>();
        childrenList = new List<GameObject>();
        childrenList.Add(gameObject); 
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.parent == null)
        {
            inContact = false;
        }
        if (!inContact){   
            target = GameObject.FindGameObjectWithTag("RotationArea").transform;
            directionVector = target.position - transform.position;
            transform.Translate(directionVector * Time.deltaTime * speed, Space.World);
		}
	}

    public void EnableInContact()
    {
        inContact = true;
    }

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "RotationArea" || col.gameObject.tag == "ColorObject" || col.gameObject.tag == "EdgeObject"){
            inContact = true;
			if(transform.parent == null){
                gameObject.tag = "EdgeObject";
                transform.SetParent(col.transform);
			}
			//colorObjectRb.isKinematic = true;
		}

		if((col.gameObject.tag == "ColorObject" || col.gameObject.tag == "EdgeObject") && transform.parent != col.transform){
			ReceiveChild(col.gameObject.GetComponent<ColorObjectController>().childrenList);
		}
	}

	public void ReceiveChild(List<GameObject> _childrenList){
        bool _checkIfAlreadyPresent = false;

        foreach(GameObject child in _childrenList)
        {
            foreach(GameObject _child in childrenList)
            {
                if(child == _child)
                {
                    _checkIfAlreadyPresent = true;
                }
            }
        }

        if (!_checkIfAlreadyPresent)
        {
            foreach (GameObject child in _childrenList)
            {
                if (child.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
                {
                    childrenList.Add(child);
                    if (transform.parent != null)
                    {
                        if (transform.parent.GetComponent<ColorObjectController>() != null)
                        {
                            transform.parent.GetComponent<ColorObjectController>().ReceiveChild(_childrenList);
                        }
                    }
                }
            }

            if (childrenList.Count >= 3)
            {
                CheckAndPop();
            }
        }
		
		
	}

	void CheckAndPop(){
		GameObject[] childArray = new GameObject[childrenList.Count];
		int counter = 0;
		foreach(GameObject child in childrenList){
			childArray[counter] = child;
			counter++;
		}

        StartCoroutine(DestroyChildrenList(childArray));
	}

    IEnumerator DestroyChildrenList(GameObject[] _childArray){
		for(int i= _childArray.Length - 1; i>=0; i--){
            if(_childArray[i] != null)
            {
                GameObject[] childrenArray = new GameObject[_childArray[i].transform.childCount];

                for (int j = 0; j < _childArray[i].transform.childCount; j++)
                {
                    childrenArray[j] = _childArray[i].transform.GetChild(j).gameObject;
                }

                GameObject popEffectInstance = (GameObject)Instantiate(popEffectPrefab, transform.position, transform.rotation);
                var _main = popEffectInstance.GetComponent<ParticleSystem>().main;
                _main.startColor = GetComponent<SpriteRenderer>().color;
                Destroy(popEffectInstance, 0.5f);

                mainSoundController.PlayPopSound();
                scoreManager.IncreaseScore();


                _childArray[i].transform.DetachChildren();

                RemoveChildFromList(_childArray[i]);
                Destroy(_childArray[i]);

                foreach (GameObject child in childrenArray)
                {
                    if (child.tag == "Outline")
                    {
                        Destroy(child);
                    }
                    else
                    {
                        child.GetComponent<ColorObjectController>().inContact = false;
                    }
                }

                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                 Destroy(_childArray[i]);
            }
        }
	}

    public void OnGameEndEffects()
    {
        GameObject popEffectInstance = (GameObject)Instantiate(popEffectPrefab, transform.position, transform.rotation);
        var _main = popEffectInstance.GetComponent<ParticleSystem>().main;
        _main.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(popEffectInstance, 0.5f);


        mainSoundController.PlayPopSound();
    }

    public void RemoveChildFromList(GameObject _child){
		childrenList.Remove(_child);
		if(transform.parent != null){
			if(transform.parent.GetComponent<ColorObjectController>() != null){
				transform.parent.GetComponent<ColorObjectController>().RemoveChildFromList(_child);
			}
		}
	}

	public void SetColor(Color _color){
        colorSpriteRenderer.color = _color;
	}
}
