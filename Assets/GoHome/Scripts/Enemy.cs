using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;
    private float sCollider;

    //public enum to define category behaviour
    public enum State


    {
        Patrol,
        Seek
    }

    //public Rigidbody rigid;
    // public float gravityDistance = 2f;

    public State currentState;
    private Transform[] waypoints;
    private int currentIndex = 1;
    

    private NavMeshAgent agent;
    private Transform target;

    // Use this for initialization
    void Start()
    {
        // Get the children from WaypointParent but also includes the parent as part of th eindex
        waypoints = waypointParent.GetComponentsInChildren<Transform>();

        // Get the AI component

        agent = GetComponent<NavMeshAgent>();
        // just in case make state Patrol
        currentState = State.Patrol;
       
   
    }

    // Update is called once per frame
    void Update()
    {
        // using a switch, switching by our currentState (the enum public variable) 
        switch (currentState)

        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:
                Patrol();
                break;
        }

        //Patrol();
    }

    void OnDrawGizmos()
    {
        // If waypoints is not null and not empty 

        if (waypoints != null && waypoints.Length > 0)
        {

            // Get current waypoint
            Transform point = waypoints[currentIndex];

            // Draw a line from position to waypoint
            Gizmos.color = Color.blue;

            Gizmos.DrawLine(transform.position, point.position);

            // Draw stopping distance sphere
            Gizmos.DrawWireSphere(point.position, stoppingDistance);
            // Draw gravity sphere
            //   Gizmos.color = Color.cyan;
            //  Gizmos.DrawWireSphere(point.position, gravityDistance);

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
        }
    }
    void Patrol()
    {
        // 1 - Get the current waypoint from the array

        Transform point = waypoints[currentIndex];

        // 2 - Get distance from waypoint with the Vector3 function

        float distance = Vector3.Distance(transform.position, point.position);

        // 2.1 - If distance is less than gravity distance

        /*       if (distance < gravityDistance)

                {
                    // Turn gravity off

                    rigid.useGravity = false;
                }

                else // Otherwise
                {
                    // Turn gravity on
                    rigid.useGravity = true;

                }
                */
        // 3 - If distance is less than stoppingdistance 
        if (distance < stoppingDistance)
        {

            // 4 - Move to the next waypoint

            currentIndex++; //currentIndex= currentIndex + 1;

            // 4.1 - If currentIndex >= way.points.Length
            if (currentIndex >= waypoints.Length)
            {
                // 4.2 - Set currentIndex to 1
                currentIndex = 1;
            }


        }


        // 5 - Translate Enemy towards current waypoint, Vector3.Movetowards updates with an increasing number from point a to point b.
        //   transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
        //  transform.LookAt(point.position);

        //5 - Use NavmeshAgent to follow the current waypoint

        agent.SetDestination(point.position);
    }

    void Seek()
    {
        // Get enemy to follow target 

        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            //set target to the OTHER thing in our zone
            target = other.transform;
            Debug.Log("Seeking");
            //switch state to seek
            currentState = State.Seek;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //switch state back to patrol as we lost our dude  
        if (other.gameObject.CompareTag("Player"))

        {
            Debug.Log("Patrolling");
            currentState = State.Patrol;        }

    }
}
