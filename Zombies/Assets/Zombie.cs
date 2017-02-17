using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    private Animator m_Animator;

	// Use this for initialization
	void Start () {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("isWalking", true);
    }

    void OnCollisionStay(Collision collision) {
        if (collision.collider.tag.Equals("Player")) {
            Debug.Log("Hit Player");
            m_Animator.SetBool("isWalking", false);
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.collider.tag.Equals("Player")) {
            Debug.Log("Left Player");
            m_Animator.SetBool("isWalking", true);
        }
    }
}
