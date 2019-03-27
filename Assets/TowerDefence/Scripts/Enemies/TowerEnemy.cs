using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class TowerEnemy : MonoBehaviour {


    public int maxHealth = 100;

    // endpoint of the navmesh for the enemies to go towards
    public Transform target;
 
    private NavMeshAgent agent;
        private float health = 0;

	// Use this for initialization
	void Start () {
        // Set health to whatever the maxhealth is at the start
        health = maxHealth;
        // Getting the navmesh component
        agent = GetComponent<NavMeshAgent>();
        // follow destination
        agent.SetDestination(target.position);
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)


        {
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
       	
	}
}
