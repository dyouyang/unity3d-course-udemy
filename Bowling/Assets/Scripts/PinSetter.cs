using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text numPins;
	public int lastStandingCount = -1;

    private bool ballEnteredBox;
	private float lastPinCountChangeTime;

	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball> ();
        ballEnteredBox = false;
	}
	
	// Update is called once per frame
	void Update () {
		numPins.text = StandingCount().ToString();

		if (ballEnteredBox) {
			CheckStanding ();
		}
	}

	void CheckStanding () {
		int standingCount = StandingCount();

		if (standingCount != lastStandingCount) {
			// Pin count has changed since last call, update count and time.
			lastStandingCount = standingCount;
			lastPinCountChangeTime = Time.timeSinceLevelLoad;
		} else if (Time.timeSinceLevelLoad - lastPinCountChangeTime > 3f) {
			// Pin count has not changed for 3 seconds, consider stable
			OnPinsSettled ();
		}
		// Count is same, but we haven't met the time threshold yet, do nothing.
	}

	void OnPinsSettled () {
		print ("Pins have settled");
		lastStandingCount = -1; // reset
		ballEnteredBox = false;
		numPins.color = Color.green;
		ball.Reset ();
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

	public int StandingCount() {

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
