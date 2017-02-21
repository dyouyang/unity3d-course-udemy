using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    Vector3 input = new Vector3();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer) {
            return;
        }

        input.x = CrossPlatformInputManager.GetAxis("Horizontal");
        input.y = 0f;
        input.z = CrossPlatformInputManager.GetAxis("Vertical");
        transform.Translate(input);
	}

    public override void OnStartLocalPlayer() {
        base.OnStartLocalPlayer();
        GetComponentInChildren<Camera>().enabled = true;
        GetComponentInChildren<AudioListener>().enabled = true;
    }
}
