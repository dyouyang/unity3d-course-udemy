using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private AudioSource audioSource;
	private Rigidbody rigidBody;

	private Vector3 initialPos;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

		initialPos = transform.position;
    }

    public void launchBall(Vector3 launchVelocity) {
        rigidBody.useGravity = true;
        audioSource.Play();
        rigidBody.velocity = launchVelocity;
    }

	public void Reset () {
		transform.position = initialPos;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}
}
