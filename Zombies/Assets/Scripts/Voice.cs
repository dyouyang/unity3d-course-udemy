using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour {

    public AudioClip callHeli;
    public AudioClip foundArea;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public void PlayFoundArea() {
        audioSource.clip = foundArea;
        audioSource.Play();
    }

    public void PlayCallHeli() {
        audioSource.clip = callHeli;
        audioSource.Play();
    }
}
