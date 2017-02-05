using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform spawnPointsParent;
    public Helicopter helicopter;

    // Toggle "button" to respawn manually.
    public bool respawn = false;

    private Voice voice;

	// Use this for initialization
	void Start () {
        voice = GetComponentInChildren<Voice>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (respawn == true) {
			Respawn ();
		}

        if (Input.GetButtonDown("CallHeli") && !helicopter.getIsCalled()) {
            // Order here matters, is called must be set first otherwise future Updates
            // may still retrieve false;
            helicopter.CallForRescue();
            voice.PlayCallHeli();
        }
    }

	private void Respawn() {
		Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform> ();

		// Index 0 is the parent's transform, start at index 1.
		Transform randomSpawn = spawnPoints [Random.Range (1, spawnPoints.Length)];
		gameObject.transform.position = randomSpawn.transform.position;
		respawn = false;
	}

    private void FoundClearArea() {
        Debug.Log("clear area found");
        voice.PlayFoundArea();
    }
}
