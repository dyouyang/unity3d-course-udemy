using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;

	private Animator animator;
    private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
        pinCounter = FindObjectOfType<PinCounter>();
	}

	public void HandleAction(ActionMaster.Action action) {

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

				// Return to fully standing just in case of tiny angles.
				pin.transform.rotation = Quaternion.identity;
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
        pinCounter.Reset();
	}

    void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponentInParent<Pin>() != null) {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
