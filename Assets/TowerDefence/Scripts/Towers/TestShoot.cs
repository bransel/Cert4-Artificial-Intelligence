﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShoot : MonoBehaviour
{
    public float attackRate = 1f;
    private float attackTimer = 0f;
    public GameObject projectilePrefab;
    public Transform point;
    // Use this for initialization
    void Start() {
    }



// Update is called once per frame
 void Update()
{

    // Count up the timer
    attackTimer += Time.deltaTime;
       
            if (attackTimer >= attackRate)
            {
            // attack the enemy!
            Shoot();
                // Reset timer
                attackTimer = 0f;



            }
}
 public void Shoot()
    {


        // Spawn projectile at position and rotation of Player
        GameObject projectile = Instantiate(projectilePrefab, point.position, transform.rotation);

        // Get Rigidbody2D from projectile
        ProjectileCannon bullet = projectile.GetComponent<ProjectileCannon>();


        bullet.Fire(transform.forward);


    }
}
