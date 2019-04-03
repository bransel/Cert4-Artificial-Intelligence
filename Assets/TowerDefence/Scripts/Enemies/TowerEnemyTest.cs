using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class TowerEnemyTest : MonoBehaviour {


    public int maxHealth = 100;

    // endpoint of the navmesh for the enemies to go towards
    public Transform target;
    private TowerHP currentEnemy;
    private NavMeshAgent agent;
        private float health = 0;
    public GameObject end;
    public float attackRange =2f;
   

    
    // Use this for initialization
    void Start()
    {
        // Set health to whatever the maxhealth is at the start
        health = maxHealth;
        // Getting the navmesh component
        agent = GetComponent<NavMeshAgent>();
       

        
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
    void Update()
    {
        end = GameObject.FindGameObjectWithTag("End");

        DetectEnemies();

        if (currentEnemy != null)
        {

            target = currentEnemy.transform;
            agent.SetDestination(target.position);

       


        }






        else
        {

            target = end.GetComponent<Transform>();
            agent.SetDestination(target.position);
        }

        // follow destination
    }
  

 
    void DetectEnemies()
    {
        // reset current enemy
        //currentEnemy = null;
        // Perform OverlapSphere
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange);
        // Loop through everything we hit

        foreach (var hit in hits)
        {
            TowerHP enemy = hit.GetComponent<TowerHP>();
            if (enemy)
            {
                // Set current enemy to that one
                currentEnemy = enemy;
                Debug.Log("I found you");
            }
        }

    }
}

   
