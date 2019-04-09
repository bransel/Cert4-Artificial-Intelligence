using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnRate = 1f; // Rate of spawn (in seconds)
    public GameObject enemy;
    void Start () {
        InvokeRepeating("SpawnLoop", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnLoop()
    {
        GameObject clone = Instantiate(enemy, transform.position, transform.rotation);
        clone.SetActive(true);
    }

}
