using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

    public Helicopter helicopter;
    public AudioClip callHeli;

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
}
