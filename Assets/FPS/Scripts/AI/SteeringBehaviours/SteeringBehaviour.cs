using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{
    public float weighting =  7.5f;
    protected ArtIn owner; // Referece to owner (for getting Velocity)

    // Start is called before the first frame update
    void Awake()
    {
        // Get the AI script that this steeing behaviour is attached to
        owner = GetComponent<ArtIn>();
    }

  

    public virtual Vector3 GetForce()
    {
        // Set force to zero
        Vector3 force = Vector3.zero;
       
        // Do nothing in the base class (always returns zero) 

        // return force
        return force;
    }
}
