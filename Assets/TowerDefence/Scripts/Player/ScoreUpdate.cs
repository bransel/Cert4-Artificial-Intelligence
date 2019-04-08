using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text text = this.GetComponent<Text>();
        text.text = ResourceManager.Score.ToString();
	}
}
