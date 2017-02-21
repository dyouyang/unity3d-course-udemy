using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    Vector3 input = new Vector3();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        input.x = CrossPlatformInputManager.GetAxis("Horizontal");
        input.y = 0f;
        input.z = CrossPlatformInputManager.GetAxis("Vertical");
        transform.Translate(input);
	}
}
