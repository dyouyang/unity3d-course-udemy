using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool inPlay;

    private AudioSource audioSource;
	private Rigidbody rigidBody;
	private Vector3 initialPos;

	// Use this for initialization
	void Start () {
		inPlay = false;
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

		initialPos = transform.position;
    }

    public void launchBall(Vector3 launchVelocity) {
		if (!inPlay) {
			inPlay = true;
			rigidBody.useGravity = true;
			audioSource.Play ();
			rigidBody.velocity = launchVelocity;
		}
    }

	public void Reset () {
		inPlay = false;
		transform.position = initialPos;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}
}
