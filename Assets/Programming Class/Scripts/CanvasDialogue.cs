using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDialogue : MonoBehaviour {
    public string[] dlgText;
    public int index, optionsIndex;
    private Text currentText;
    private GameObject back;
    private GameObject next;
    private Button backB;
    private Button nextB;

    // Use this for initialization
    void Start () {
       currentText = this.GetComponent<Text>();
        back = transform.Find("Back").gameObject;
        next = transform.Find("Next").gameObject;
        backB = back.GetComponent<Button>();
        nextB = next.GetComponent<Button>();
	}

    // Update is called once per frame
    void Update() {

        currentText.text = dlgText[index];

        if (index == 0)
        {
            back.SetActive(false);
        }
        else if (index < dlgText.Length -1)
        {
          back.SetActive(true);
            Debug.Log(dlgText.Length);

        }

        else if (index == dlgText.Length)
        {

            Text text = next.GetComponentInChildren<Text>();
            text.text = "DONE";

        


        }


	}

    public void Next()
    {
        index += 1; 
    }

    public void Back()
    {
        index -= 1;
    }
}
