using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text numPins;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		numPins.text = standingCount().ToString();
	}

	public int standingCount() {

		int count = 0;
		Pin[] pins = FindObjectsOfType<Pin> ();
		foreach (Pin pin in pins) {
			if (pin.IsStanding ()) {
				count++;
			}
		}
		return count;
	}
}
