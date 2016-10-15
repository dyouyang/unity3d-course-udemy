using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float initialVelocity;

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
        rigidbody.velocity = new Vector3(0, 0, initialVelocity);
    }
}
