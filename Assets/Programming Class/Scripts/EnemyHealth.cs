using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public float curHP =100;
    public float maxHP = 100;
    public Slider healthBar;
    public Canvas myCanvas;




	// Use this for initialization
	private void Start () {
        //transform.Find looks within the childen and the (" ...") is what it can search within. 
        myCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        healthBar = myCanvas.transform.Find("Slider").GetComponent<Slider>();
	}

    // Update is called once per frame
    void Update()
    {

        // clamp sets a value between a min and max, clamp01 sets it between 0 and 1 
        healthBar.value = Mathf.Clamp01(curHP / maxHP);
        myCanvas.transform.LookAt(Camera.main.transform);
        // transform.Lookat - Rotates the transform so the forward vector points at /target/'s current position.

    }
}
