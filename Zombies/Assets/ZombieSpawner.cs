using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieSpawner : MonoBehaviour {

    public float spawnInterval;
    public GameObject toSpawn;

    private float lastSpawnTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Time.time - lastSpawnTime > spawnInterval) {
            SpawnZombieAtRandomNearbyLocation();
            lastSpawnTime = Time.time;
        }
	}

    private void SpawnZombieAtRandomNearbyLocation() {
        float randomX = transform.position.x + UnityEngine.Random.Range(-50f, 50f);
        float randomZ = transform.position.z + UnityEngine.Random.Range(-50f, 50f);
        float increasedHeight = transform.position.y + 10f;

        GameObject zombie = Instantiate(toSpawn, new Vector3(randomX, increasedHeight, randomZ), Quaternion.identity);
        zombie.GetComponent<Zombie>().playerGameObject = this.gameObject;
        zombie.GetComponent<AICharacterControl>().SetTarget(gameObject.transform);
        zombie.GetComponent<NavMeshAgent>().speed = UnityEngine.Random.Range(1f, 10f);
    }
}
