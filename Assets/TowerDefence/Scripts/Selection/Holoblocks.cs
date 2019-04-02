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
        if(Trig == true)
        {
            Debug.Log("Cannot place blocks");
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Block")){
            Trig = true; }

        
    }

    private void OnTriggerExit(Collider other)
    {
        Trig = false;
            
    }

}
