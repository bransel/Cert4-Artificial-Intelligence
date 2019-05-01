using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLookAtDirection : MonoBehaviour
{
    public Transform target; // Reference to a target
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {

        // Rotate to target direction
        transform.rotation = Quaternion.LookRotation(target.forward);
    }
}
