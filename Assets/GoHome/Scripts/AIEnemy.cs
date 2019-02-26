using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent; // reference to NavMeshAgent component

    // Use this for initialization
    void Start()
    {
        // Getting the NavMeshAgent from the list of components (in inspector)
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        // Tell NavMeshAgent to follow target position

        agent.SetDestination(target.position);
    }
}
