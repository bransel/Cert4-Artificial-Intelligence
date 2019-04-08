using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public static int BPollen, YPollen, RPollen, Score;//current resources
    public GameObject Blue, Yellow, Red;
	// Use this for initialization
	void Start () {

        BPollen = 2;
        YPollen = 2;
        RPollen = 2;
        Score = 0;
    }
	

	// Update is called once per frame
	void Update () {

        Text BPollenCount = Blue.GetComponentInChildren<Text>();
        BPollenCount.text = BPollen.ToString();
        Text YPollenCount = Yellow.GetComponentInChildren<Text>();
        YPollenCount.text = YPollen.ToString();
        Text RPollenCount = Red.GetComponentInChildren<Text>();
        RPollenCount.text = RPollen.ToString();



    }
}
