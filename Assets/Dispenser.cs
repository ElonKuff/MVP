using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour{

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public float radius = 1f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}
	
    public void SpawnObject() {
        Instantiate(spawnee, Random.insideUnitCircle * radius, transform.rotation);
        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }
}
