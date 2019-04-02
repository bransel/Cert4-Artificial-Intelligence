using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public float y;
    public float rotSpeed = 2;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        this.gameObject.transform.Rotate(0, y, 0);

        if (Input.GetKey(KeyCode.D))
        {
            y = rotSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            y = -rotSpeed * Time.deltaTime;
        }
        else { y = 0; }
		
	}
}
