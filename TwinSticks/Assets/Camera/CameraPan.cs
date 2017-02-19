using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraPan : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("RHorizontal : " + CrossPlatformInputManager.GetAxis("RHorizontal"));
        //Debug.Log("RVertical : " + CrossPlatformInputManager.GetAxis("RVertical"));
    }

    void LateUpdate() {
        transform.LookAt(player.transform);
    }
}
