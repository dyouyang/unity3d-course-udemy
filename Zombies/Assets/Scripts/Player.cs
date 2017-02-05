using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform spawnPointsParent;

	// Toggle "button" to respawn manually.
	public bool respawn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (respawn == true) {
			Respawn ();
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
        GetComponentInChildren<Voice>().PlayFoundArea();
    }
}
