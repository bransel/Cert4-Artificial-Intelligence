using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holoblocks : MonoBehaviour {

    public bool Trig = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Trig = true;
        Debug.Log("Cannot place blocks");
    }

    private void OnTriggerExit(Collider other)
    {
        Trig = false;
    }

}
