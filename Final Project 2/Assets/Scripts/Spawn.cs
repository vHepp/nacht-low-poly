using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public GameObject zombiePrefab;
	public Countable zombieCountable;

	public float spawnDelay = 5f;
	public float nextTimeToSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if (zombieCountable.getReserve() > 0 && zombieCountable.getCount() < 24 && Time.time >= nextTimeToSpawn) {
			nextTimeToSpawn = Time.time + spawnDelay;
			zombieCountable.decrementReverve();
			GameObject g = Instantiate(zombiePrefab, transform);
		}
		
    }
}
