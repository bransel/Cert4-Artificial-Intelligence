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
        public float maxVelocity = 3f; // Max velocity an asteroid can move
        public float spawnPadding = 2f; // Padding to spawn

    void OnDrawGizmos()
        {
            Bounds camBounds = Camera.main.GetBounds(spawnPadding);
            Gizmos.color = Color.red;
            //Gizmos.DrawWireSphere(transform.position, spawnRadius);
            Gizmos.DrawWireCube(camBounds.center, camBounds.size);
        }
        /*
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

        */

        //Spawns an asteroid at a position specified

        public void Spawn(GameObject prefab, Vector3 position)
        {
            // Randomize a rotation for the asteroid
            Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            // Spawn a random asteroid at random position and default Quaternion rotation

            GameObject asteroid = Instantiate(prefab, position, randomRot, transform);

            // Get Rigidbody 2D from asteroid

            Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();

            // Apply random force to rigidbody
            Vector2 randomForce = Random.insideUnitCircle * maxVelocity;
            rigid.AddForce(randomForce, ForceMode2D.Impulse);
        }

        // Spawns a random asteroid in the array at a random position

        void SpawnLoop()

        {
            // Get camera's bounds using Extension Method
            Bounds camBounds = Camera.main.GetBounds(spawnPadding);

            // Generate a random position inside sphere with spawn padding (radius)

            //Vector3 randomPos = Random.insideUnitSphere * spawnPadding;
            Vector2 randomPos = camBounds.GetRandomPosOnBounds(); 

            // Generate random index number from the asteroid prefabs array length
            int randomIndex = Random.Range(0, asteroidPrefabs.Length);

            // Get random asteroid prefab from array using index
            GameObject randomAsteroid = asteroidPrefabs[randomIndex];

            // Spawn using random position

            Spawn(randomAsteroid, randomPos);

        }

        // Use this for initialization
        void Start()
        {
            // Calls a function a specified amount of times
         
            InvokeRepeating("SpawnLoop", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
