﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Transform spawnPointsParent;
    public Helicopter helicopter;
    public GameObject landingZone;
    public int maxHp;
    public Slider healthBar;

    private int currentHp;
    private LandingZoneChecker landingZoneChecker;

    // Toggle "button" to respawn manually.
    public bool respawn = false;

    private Voice voice;

	// Use this for initialization
	void Start () {
        voice = GetComponentInChildren<Voice>();
        landingZoneChecker = GetComponentInChildren<LandingZoneChecker>();
        currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		if (respawn == true) {
			Respawn ();
		}

        if (Input.GetButtonDown("CallHeli") && !helicopter.getIsCalled() && landingZoneChecker.foundArea) {
            // Order here matters, is called must be set first otherwise future Updates
            // may still retrieve false;
            helicopter.CallForRescue();
            DeployFlare();
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

    private void DeployFlare() {
        helicopter.landingZone = Instantiate(landingZone, transform.position, Quaternion.identity);
    }

    public void takeDamage(int damage) {
        Debug.Log("taking damage: " + damage);
        currentHp -= damage;
        healthBar.value = (float)currentHp / maxHp;
    }
}
