using UnityEngine;
using System.Collections;

public class LaneBox : MonoBehaviour {

	public GameObject pinSetter;

	void OnTriggerExit(Collider other) {
		if (other.gameObject.GetComponent<Ball>() != null) {
			pinSetter.GetComponent<PinSetter> ().OnBallLeftLaneBox ();
		}
	}
}
