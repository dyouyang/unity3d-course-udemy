using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZoneChecker : MonoBehaviour {

    public bool foundArea = false;

    void OnTriggerEnter(Collider collider) {
        Debug.Log("LandingZoneChecker onTriggerEnter " + collider.tag);
        if (collider.tag.Equals("LandingZone")) {
            foundArea = true;
            SendMessageUpwards("FoundClearArea");
        }
    }
}
