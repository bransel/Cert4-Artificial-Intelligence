using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCoding : MonoBehaviour {
    public float scrW, scrH;
    private void OnGUI()
    {
        if (scrW != Screen.width / 16)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;
        }
        /*if (GUI.Button(new Rect(0, 0, scrW*3, scrH*1.5f), "Button"))
        {


        }*/

        for (int x = 0; x< 16; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                GUI.Box(new Rect(scrW*x, scrH*y, scrW, scrH), " 0"  );
            }
        }
    }


}
