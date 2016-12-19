using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text numPins;

    private bool ballEnteredBox;

	// Use this for initialization
	void Start () {
        ballEnteredBox = false;
	}
	
	// Update is called once per frame
	void Update () {
		numPins.text = standingCount().ToString();
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Ball>() != null) {
            numPins.color = Color.red;
            ballEnteredBox = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponentInParent<Pin>() != null) {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
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
