using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 initialVelocity;

    private AudioSource audioSource;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();

        launchBall();
    }

    private void launchBall() {
        audioSource.Play();
        rigidbody.velocity = initialVelocity;
    }
}
