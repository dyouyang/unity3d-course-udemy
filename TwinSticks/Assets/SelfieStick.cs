using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

    public float rotateSpeed = 2f;

    private GameObject player;
    private Vector3 armRotationInEuler;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotationInEuler = transform.rotation.eulerAngles;
    }
    // Update is called once per frame
    void Update () {
        armRotationInEuler.y += CrossPlatformInputManager.GetAxis("RHorizontal") * rotateSpeed;
        armRotationInEuler.z += CrossPlatformInputManager.GetAxis("RVertical") * rotateSpeed;
        transform.rotation = Quaternion.Euler(armRotationInEuler);
        transform.position = player.transform.position;
	}
}
