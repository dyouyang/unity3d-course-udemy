using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    private bool isCalled;

    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        isCalled = false;
        rigidBody = GetComponent<Rigidbody>();
	}

    public void CallForRescue() {
        isCalled = true;
        rigidBody.velocity = new Vector3(0, 0, 50);
    }

    public bool getIsCalled() {
        return isCalled;
    }
}
