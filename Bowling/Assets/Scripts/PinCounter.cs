using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    public Text numPins;

    private int lastStandingCount = -1;
    private bool ballLeftLaneBox;
    private float lastPinCountChangeTime;
    // Updated only once per bowl.  Used to determine the number of pins knocked down.
    private int lastSettledCount = 10;
    private GameManager gameManager;

    void Start() {
        ballLeftLaneBox = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnPinsSettled() {
        print("Pins have settled");
        int fallenCount = lastSettledCount - StandingCount();
        lastSettledCount = StandingCount();
        gameManager.Bowl(fallenCount);
        //pinSetter.HandleAction(actionMaster.Bowl(fallenCount));
        Debug.Log("Fallen Count " + fallenCount.ToString());
        lastStandingCount = -1; // reset
        ballLeftLaneBox = false;
        numPins.color = Color.green;
    }

    void CountStandingAndCheckSettled() {
        int standingCount = StandingCount();

        if (standingCount != lastStandingCount) {
            // Pin count has changed since last call, update count and time.
            lastStandingCount = standingCount;
            lastPinCountChangeTime = Time.timeSinceLevelLoad;
        } else if (Time.timeSinceLevelLoad - lastPinCountChangeTime > 3f) {
            // Pin count has not changed for 3 seconds, consider stable
            OnPinsSettled();
        }
        // Count is same, but we haven't met the time threshold yet, do nothing.
    }

    public int StandingCount() {

        int count = 0;
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (Pin pin in pins) {
            if (pin.IsStanding()) {
                count++;
            }
        }
        return count;
    }

    // Update is called once per frame
    void Update() {
        numPins.text = StandingCount().ToString();

        if (ballLeftLaneBox) {
            CountStandingAndCheckSettled();
        }
    }

    public void OnBallLeftLaneBox() {
        numPins.color = Color.red;
        ballLeftLaneBox = true;
    }

    public void Reset() {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<Ball>() != null) {
            OnBallLeftLaneBox();
        }
    }
}
