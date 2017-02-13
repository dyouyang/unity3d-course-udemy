using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    Light flashlight;

	// Use this for initialization
	void Start () {
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("ToggleFlashlight")) {
            flashlight.enabled = !flashlight.enabled;
        }
	}
}
