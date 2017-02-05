using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    public float timeScale;

    private float sunInitialX;

    void Start() {
        sunInitialX = transform.eulerAngles.x;
    }

    void Update() {
        //RotateDirect();
        RotateRelative();
    }

    /**
    These next two methods perform the exact same thing (rotating the directional sun east to west), but in different ways.

    The direct method calculates the rotation based off time since game start, and sets it to the x rotation value,
    keeping y and z the same.

    The relative method takes the current rotation and figures out (based on the time since last frame / rotation event)
    how many angles to rotate this frame, and then rotates the object itself by that amount this frame.
    */

    private void RotateDirect() {
        float currentTimeInSeconds = Time.time;
        float degreesPerSecond = (float)360 / (24 * 60 * 60) * timeScale;

        transform.eulerAngles = new Vector3(
            sunInitialX + currentTimeInSeconds * degreesPerSecond,
            transform.eulerAngles.y,
            transform.eulerAngles.z
            );
    }

    private void RotateRelative() {
        float timeSinceLastRotate = Time.deltaTime;
        float degreesPerSecond = (float)360 / (24 * 60 * 60) * timeScale;

        transform.Rotate(new Vector3(timeSinceLastRotate * degreesPerSecond, 0, 0));
    }
}
