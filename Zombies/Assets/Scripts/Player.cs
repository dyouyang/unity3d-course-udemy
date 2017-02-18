using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Transform spawnPointsParent;
    public Helicopter helicopter;
    public GameObject landingZone;
    public int maxHp;
    public Slider healthBar;
    public GameStateManager gameStateManager;

    private int currentHp;

    // Toggle "button" to respawn manually.
    public bool respawn = false;
    
    public bool foundArea = false;

    private Voice voice;

	// Use this for initialization
	void Start () {
        voice = GetComponentInChildren<Voice>();
        currentHp = maxHp;
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
