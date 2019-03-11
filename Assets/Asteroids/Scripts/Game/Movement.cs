using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Movement : MonoBehaviour
    {
        public float speed = 20f; // Units to travel per second
        public float rotationSpeed = 360f; // Amount of rotation per second
        private Rigidbody2D rigid; // References to the attached Rigidbody2D
        public GameObject projectilePrefab; // prefab to spawn while shooting
        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
          // rigid.AddForce(transform.up * speed);
        }

        // Update is called once per frame
        void Update()
        {

            // check a key press
            if (Input.GetKey(KeyCode.A))
            {
                //Rotate left (translating)
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            
                // If you want to use the Rigidbody to rotate the player, use this: (using physics)
                //rigid.rotation += rotationSpeed * Time.deltaTime;

            }
            // check d key press
            if (Input.GetKey(KeyCode.D))
            {
                // Rotate right
                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);

                
            }

            // check if w key is pressed

            if (Input.GetKey(KeyCode.W))
            {
                //Move in facing direction
                rigid.AddForce(transform.up * speed);
            }

            if (Input.GetKey(KeyCode.S))

            {
                rigid.AddForce(-transform.up * speed);
            }
            // If player hits Space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Shoot a projectile
                Shoot();
            }
        }
        // Shoots a projectile in a set direction
        void Shoot()
        {
            // Spawn projectile at position and rotation of Player
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Get Rigidbody2D from projectile
            Projectile bullet = projectile.GetComponent<Projectile>();
            bullet.Fire(transform.up);

        }

        
           
        
    }
}