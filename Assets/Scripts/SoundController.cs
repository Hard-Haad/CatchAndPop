using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour { 

    AudioSource audioSource;
    
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
    public void PlayPopSound()
    {
        audioSource.Play();
    }
}
