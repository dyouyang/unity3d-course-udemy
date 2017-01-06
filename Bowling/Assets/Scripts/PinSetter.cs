using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text numPins;
	public GameObject pinSet;

	private int lastStandingCount = -1;
	private bool ballLeftLaneBox;
	private float lastPinCountChangeTime;
	// Updated only once per bowl.  Used to determine the number of pins knocked down.
	private int lastSettledCount = 10;

	private ActionMaster actionMaster;
	private Animator animator;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball> ();
        ballLeftLaneBox = false;
		actionMaster = new ActionMaster ();
		animator = GetComponent<Animator> ();
	}

	public void OnBallLeftLaneBox()  {
		numPins.color = Color.red;
		ballLeftLaneBox = true;
	}

	// Update is called once per frame
	void Update () {
		numPins.text = StandingCount().ToString();

		if (ballLeftLaneBox) {
			CountStandingAndCheckSettled ();
		}
	}

	void CountStandingAndCheckSettled () {
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
		int fallenCount = lastSettledCount - StandingCount ();
		lastSettledCount = StandingCount ();
		HandleAction(actionMaster.Bowl (fallenCount));
		Debug.Log ("Fallen Count " + fallenCount.ToString ());
		lastStandingCount = -1; // reset
		ballLeftLaneBox = false;
		numPins.color = Color.green;
		ball.Reset ();
	}

	private void HandleAction(ActionMaster.Action action) {

		switch (action) {
		case ActionMaster.Action.Tidy:
			animator.SetTrigger ("tidyTrigger");
			break;
		case ActionMaster.Action.Reset:
			animator.SetTrigger ("resetTrigger");
			break;
		case ActionMaster.Action.EndTurn:
			animator.SetTrigger ("resetTrigger");
			break;
		case ActionMaster.Action.EndGame:
			print ("Game over");
			break;
		default:
			throw new UnityException("Could not handle action, no match");
		}
	}

	void RaisePins() {
		Debug.Log ("Raising pins");
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				pin.Raise ();
			}
		}
	}

	private void LowerPins() {
		Debug.Log ("Lowering pins");
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				pin.Lower ();
			}
		}
	}

	private void RenewPins() {
		Debug.Log ("Renewing pins");
		Instantiate (pinSet, new Vector3 (0, 10, 1829), Quaternion.identity);
		lastSettledCount = 10;
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
