using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject[] asteroidPrefabs; // Array of prefabs to spawn
        public float spawnRate = 1f; // Rate of spawn (in seconds)
        public float spawnRadius = 5f; // Distance to spawn each asteroid

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        void Spawn()
        {
            //Randomize a position
            Vector3 rand = Random.insideUnitSphere * spawnRadius;
            // Cancel the Z position
            rand.z = 0f;
            // Offset position from spawner location

            Vector3 position = transform.position + rand;
            // Generate a random index into prefab array
            int randIndex = Random.Range(0, asteroidPrefabs.Length);

            // Get random aseteroid using index
            GameObject randAsteroid = asteroidPrefabs[randIndex];

            // Clone / instantiate random asteroid

            GameObject clone = Instantiate(randAsteroid); // Makes a copy 

            //Set position of random asteroid
            clone.transform.position = position;

            // you can write the above instantiate in one line as Instantiate(randomAsteroid,position,Quaternion.identity)); , Quaternion.identity means default rotation at (0,0,0) 
        }

        // Use this for initialization
        void Start()
        {
            // Calls a function a specified amount of times
         
            InvokeRepeating("Spawn", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
