using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public GameObject playerGameObject;

    private Animator m_Animator;

    // Use this for initialization
    void Start() {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("isWalking", true);
    }

    void OnCollisionStay(Collision collision) {
        if (collision.collider.tag.Equals("Player")) {
            m_Animator.SetBool("isWalking", false);
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.collider.tag.Equals("Player")) {
            m_Animator.SetBool("isWalking", true);
        }
    }

    public void Attack(int damage) {
        Player player = playerGameObject.GetComponent<Player>();
        player.takeDamage(damage);
    }
}
