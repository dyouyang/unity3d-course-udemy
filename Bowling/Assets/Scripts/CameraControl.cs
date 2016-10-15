using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        cameraOffset = gameObject.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        updateCameraPosition();
	}

    void updateCameraPosition() {
        if (transform.position.z < 1729f) {
            gameObject.transform.position = ball.transform.position + cameraOffset;
        }
    }
}
