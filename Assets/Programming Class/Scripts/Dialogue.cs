using System.Collections;
using UnityEngine;

public class Dialogue : MonoBehaviour {

    public bool showDlg;
    public string[] dlgText;
    public Vector2 scr;
    public int index, optionsIndex; 

	// Use this for initialization
	void Start () {
		
	}
	
	
    // Code Version of Canvas
    // ONGUI runs along side update
	void OnGUI () {

        if (showDlg)
        {
            if(scr.x != Screen.width/16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            // GUI element of Type Box
            // new Rectangular Position and Size
            // Pos X, Pos Y, Size X, Size Y

            GUI.Box(new Rect(0, 6 * scr.y, Screen.width, 3 * scr.y), dlgText[index]);

            // have a Box that touches the left edge and goes to the right edge
            // and starts 2/3rds down the screen and is 1/3rd in size finishing at the bottom of the screen

            if (!(index >= dlgText.Length - 1 || index == optionsIndex ))
            // index < dlgText.Length , if we havent reached the end of our dialogue options
            {
                if (GUI.Button(new Rect(15f * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Next"))
                {
                    index++;
                }
            }

            else if (index == optionsIndex) 
                {

                if (GUI.Button(new Rect(13* scr.x, 8.5f* scr.y, scr.x, 0.5f*scr.y), "Accept" ))
                    {
                    index++;
                }
                if (GUI.Button(new Rect(14* scr.x, 8.5f* scr.y, scr.x, 0.5f* scr.y), "Decline"))
                {
                    index = dlgText.Length - 1;
                    // so this is the last one
                }
            
            }
            else
            {
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "DONE"))
                {
                    index = 0;
                    showDlg = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }

       

    }
}
