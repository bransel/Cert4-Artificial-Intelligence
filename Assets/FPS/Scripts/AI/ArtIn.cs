using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArtIn : MonoBehaviour
{
    public float maxVelocity = 5f, maxDistance = 5f;
    protected Vector3 velocity;

    public Vector3 Velocity
    {
        protected set { velocity = value; }
        get { return velocity; }
    }
    protected  SteeringBehaviour[] behaviours; 
    protected NavMeshAgent agent;



    void Awake()
    {
        //Get Nav Component
        agent = GetComponent<NavMeshAgent>();

        // Get all SteeringBehaviours on AI
        behaviours = GetComponents<SteeringBehaviour>();

    }


    private void Update()
    {
        CalculateForce();
    }
    //Calculates all forces from all behaviours
    public virtual Vector3 CalculateForce()
    {
        // Step 1. create a result vector 3
        //Set force to zero
        Vector3 force = Vector3.zero;

        // Step 2. Look through all behaviours and get forces
        foreach (var behaviour in behaviours)
        {
            // APPLY force to behaviour.GetForce x weighting
            force += behaviour.GetForce() * behaviour.weighting;
            // Step 3. Limit the total force to max speed
            // If force magnitude > maxSpeed
            if (force.magnitude > maxVelocity)
            {

                // Set force to force normalized x maxSpeed
                
                force = force.normalized * maxVelocity;
                //BREAk (exit the loop)
                break; 
            }

        }



        // Step 4.  Limit the total velocity to our max velocity if it exceeds
        velocity += force * Time.deltaTime;

        // if velocity magnitute > max velocity
        if (velocity.magnitude > maxVelocity)
        {
            // Set velocity to velocity normalized x max velocity 
            velocity = velocity.normalized * maxVelocity; 
        }
        // Step 5. Sample destination for NavMeshAgent 
        // If velocity magnitude > 0 (velocity not zero)
        if (velocity.magnitude > 0)
        {

            // Set pos to current (position) + velocity x delta
            Vector3 pos = transform.position + velocity * Time.deltaTime;
            NavMeshHit hit;

            // If navmesh sampleposition within navmesh 
            if (NavMesh.SamplePosition(pos, out hit, maxDistance, -1))
            {


                // set agent destination to hit position.
                agent.SetDestination(hit.position);
            }

        }

        // Step 6. Return force
        return force;

    }
}
