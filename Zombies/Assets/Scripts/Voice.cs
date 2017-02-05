using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour {

    public Helicopter helicopter;
    public AudioClip callHeli;
    public AudioClip foundArea;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("CallHeli") && !helicopter.isCalled) {
            // Order here matters, is called must be set first otherwise future Updates
            // may still retrieve false;
            helicopter.isCalled = true;
            audioSource.clip = callHeli;
            audioSource.Play();
        }
    }

    public void PlayFoundArea() {
        audioSource.clip = foundArea;
        audioSource.Play();
    }
}
