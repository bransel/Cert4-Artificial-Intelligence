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
    public float x, y, z;
    public float maxMP, curMP, maxStam, curStam, exp, curXP;

    public Data(PlayerGame player) 
        // referencing the playergame script and converting it inbetween


    {
        level = player.level;
        playerName = player.name;
        maxHP = player.maxHP;
        curHP = player.curHP;
        x = player.x;
        y = player.y;
        z = player.z;
        maxMP = player.maxMP;
        curMP = player.curMP;
        curStam = player.curStam;
        exp = player.exp;
        curXP = player.curXP;
    }


}
