using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private AudioSource audioSource;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    public void launchBall(Vector3 launchVelocity) {
        rigidbody.useGravity = true;
        audioSource.Play();
        rigidbody.velocity = launchVelocity;
    }
}
