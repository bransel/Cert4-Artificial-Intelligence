using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class Data
{ // converting to binary , those values are being converted to here 

    public int level;
    public string playerName;
    public float maxHP;
    public float curHP;

    public Data(PlayerGame player) 
        // referencing the playergame script and converting it inbetween


    {
        level = player.level;
        playerName = player.name;
        maxHP = player.maxHP;
        curHP = player.curHP;
    }


}
