﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

	public Transform spawnPointsParent;
    public Helicopter helicopter;
    public GameObject landingZone;
    public int maxHp;
    public Slider healthBar;
    public int maxStamina;
    public Slider staminaBar;
    public GameStateManager gameStateManager;

    private int currentHp;
    private int currentStamina;

    // Toggle "button" to respawn manually.
    public bool respawn = false;
    
    public bool foundArea = false;

    private Voice voice;

	// Use this for initialization
	void Start () {
        voice = GetComponentInChildren<Voice>();
        currentHp = maxHp;
        currentStamina = maxStamina;
	}
	
	// Update is called once per frame
	void Update () {
		if (respawn == true) {
			Respawn ();
		}

        if (Input.GetButtonDown("CallHeli") && !helicopter.getIsCalled() && foundArea) {
            // Order here matters, is called must be set first otherwise future Updates
            // may still retrieve false;
            helicopter.CallForRescue();
            DeployFlare();
            voice.PlayCallHeli();
            GetComponent<ZombieSpawner>().spawnInterval = 4f;
        }
        HandleStamina();
    }

    private void HandleStamina() {

        if (GetComponent<FirstPersonController>().m_IsWalking) {
            currentStamina += 1;
        } else {
            currentStamina -= 1;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        float ratio = (float)currentStamina / maxStamina;
        staminaBar.value = ratio;

        if (ratio < 0.1f) {
            GetComponent<FirstPersonController>().outOfStamina = true;
        } else {
            GetComponent<FirstPersonController>().outOfStamina = false;
        }
    }

    private void Respawn() {
		Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform> ();

		// Index 0 is the parent's transform, start at index 1.
		Transform randomSpawn = spawnPoints [UnityEngine.Random.Range (1, spawnPoints.Length)];
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
        if (currentHp <= 0) {
            gameStateManager.Lose();
        }
    }

    void OnTriggerEnter(Collider collider) {
        Debug.Log("LandingZoneChecker onTriggerEnter " + collider.tag);
        if (collider.tag.Equals("LandingZone")) {
            if (!foundArea) {
                FoundClearArea();
                foundArea = true;
            }
        } else if (collider.GetComponent<Helicopter>() != null) {
                gameStateManager.Win();
            }
        }
}
