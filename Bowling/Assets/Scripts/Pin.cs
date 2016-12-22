using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 10f;
	public float raiseDistance = 50f;

	public bool IsStanding() {
		Vector3 eulerAngles = gameObject.transform.eulerAngles;
		if (insideThreshold(eulerAngles.x) && insideThreshold(eulerAngles.z)) {
			return true;
		} else {
			return false;
		}
	}

	void Update() {
		//print (IsStanding ());
	}

	private bool insideThreshold(float angle) {
		// Sometimes 360 is returned for upright instead of 0.
		if (angle > -standingThreshold && angle < standingThreshold
		    || angle > 360 - standingThreshold && angle < 360 + standingThreshold) {
			return true;
		} else {
			return false;
		}
	}

	public void Raise() {
		transform.Translate(new Vector3(0, raiseDistance, 0));
		GetComponent<Rigidbody> ().useGravity = false;
	}

	public void Lower() {
		transform.Translate (new Vector3 (0, -raiseDistance, 0));
		GetComponent<Rigidbody> ().useGravity = true;
	}
}
