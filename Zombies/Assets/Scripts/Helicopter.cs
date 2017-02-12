using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    public GameObject landingZone;

    private bool isCalled;
    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        isCalled = false;
        rigidBody = GetComponent<Rigidbody>();
	}

    void Update() {
        if (isCalled) {
            Vector3 above = new Vector3(landingZone.transform.position.x, transform.position.y, landingZone.transform.position.z);
            transform.LookAt(above);
            float step = 50 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, above, step);
        }
    }

    public void CallForRescue() {
        isCalled = true;
    }

    public bool getIsCalled() {
        return isCalled;
    }
}
