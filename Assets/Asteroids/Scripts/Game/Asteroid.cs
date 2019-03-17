﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public GameObject[] asteroidPieces; // Pieces of Asteroids to spawn
    public int spawnAmount = 4;
    public float maxVelocity = 3f;

    // Spawns a random asteroid in a random direction
    void Spawn()
    {
        // Generate random index into the asteroid pieces array
        int randomIndex = Random.Range(0, asteroidPieces.Length);

        // Select random asteroid piece
        GameObject asteroidPiece = asteroidPieces[randomIndex];

        // Ask the Asteroid Manager to spawn a new asteroid piece at a position
        Asteroids.AsteroidSpawner.Spawn(asteroidPiece, transform.position);


    }

    // Spawns Asteroid pieces when Asteroid get destroyed

    public void Destroy()
    {
        //Destroy Self
        Destroy(gameObject);

        // If there are assigned asteroid pieces

        if (asteroidPieces.Length > 0)
        {
            // Loop through the specified spawn amount
            for (int i = 0; i < spawnAmount; i++)
            {
                //spawn an asteroid
                Spawn();
            }
       }

       


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
