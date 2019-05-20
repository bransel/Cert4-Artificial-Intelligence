using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WarriorData
{
    public int skinIndex, hairIndex, mouthIndex, eyesIndex, clothesIndex, armourIndex, selectedIndex;
    public string playerName; 

    public WarriorData(CustomisationSet custom)
    {
        skinIndex = custom.skinIndex;
       hairIndex = custom.hairIndex;
        mouthIndex = custom.mouthIndex;
        eyesIndex = custom.eyesIndex;
        clothesIndex = custom.clothesIndex;
        armourIndex = custom.armourIndex;
        selectedIndex = custom.selectedIndex;
        playerName = custom.charName;


    }
}
