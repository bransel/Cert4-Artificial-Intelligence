using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public Transform target;
    public float stoppingDistance;

    
    // Calculate force using target and return it
    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        //Step 1 check if we have a target
        // If target is null

        if (target == null)
        {

            // return force (zero)
            return force;
        }

        // Step 2, get direction we want to go
        // Set desiredForce to target - current
        Vector3 desiredForce = target.position - transform.position;

        // step 3 Apply weighting to desired force
        // If desired force distance is greater than stopping distance
        if (desiredForce.magnitude > stoppingDistance)
        {


            // set desiredforce to restricted desiredforce (using weighting) 
            desiredForce = desiredForce.normalized * weighting;
            // Set force to desiredforce - velocity 

            force = desiredForce - owner.Velocity;
        }

        return force;


    }
}
