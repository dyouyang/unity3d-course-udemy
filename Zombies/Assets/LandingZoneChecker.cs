using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZoneChecker : MonoBehaviour {

    public float timeSinceLandingZoneClear = 0f;

    private bool foundArea = false;

	// Update is called once per frame
	void Update () {
        timeSinceLandingZoneClear += Time.deltaTime;

        if (timeSinceLandingZoneClear > 1f && !foundArea) {
            foundArea = true;
            SendMessageUpwards("FoundClearArea");
        }
	}

    void OnTriggerStay () {
        timeSinceLandingZoneClear = 0f;
    }
}
