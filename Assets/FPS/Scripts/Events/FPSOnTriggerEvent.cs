using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FPSOnTriggerEvent : MonoBehaviour
{
    // Reference Tag to detect collisions with

    public string hitTag;
    public UnityEvent onEnter;


    private void OnTriggerEnter(Collider other)
    {
        // If hitting hit tag OR hittag is set to noting
        if(other.tag == hitTag || hitTag =="")
        {
            onEnter.Invoke();
        }

    }
}
