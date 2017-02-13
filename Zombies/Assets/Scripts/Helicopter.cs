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
            Vector3 aboveLandingZone = new Vector3(landingZone.transform.position.x, transform.position.y, landingZone.transform.position.z);
            if (!transform.position.Equals(aboveLandingZone)) {
                // Fly towards spot above the landing zone.
                float step = 50 * Time.deltaTime;
                transform.LookAt(aboveLandingZone);
                transform.position = Vector3.MoveTowards(transform.position, aboveLandingZone, step);
            } else {
                // Descend to landing zone.
                transform.position = Vector3.MoveTowards(transform.position, landingZone.transform.position, 5 * Time.deltaTime);
            }
        }
    }

    public void CallForRescue() {
        isCalled = true;
    }

    public bool getIsCalled() {
        return isCalled;
    }
}
