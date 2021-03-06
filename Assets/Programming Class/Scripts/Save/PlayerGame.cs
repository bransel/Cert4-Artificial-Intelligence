﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{


    #region Key Variables for the player
    //health, level, exp, mana, stamina, position, name, customisation etc.
    public int level;
    // new name specifically to do with this script, new keyword?
    public new string name;
    public float maxHP;
    public float curHP;
    public float x, y, z, rx, ry, rz;
    public float maxMP, curMP, maxStam, curStam, exp, curXP;
    //reference to the Healthbar script, and giving it a reference health for this script.
    public HealthBar health;
    public OtherBars bars;

    public Checkpoint.CheckPoint checkPoint;


    #endregion
    // Use this for initialization
    public void SaveFunction()
    {
        // making sure our variable maxHP lines up with health script's Maxhealth variable and also curhealth before we save
        maxHP = health.maxHealth;
        curHP = health.curHealth;
        maxMP = bars.maxMana;
        curMP = bars.curMana;
        maxStam = bars.maxStam;
        curStam = bars.curStam;
        exp = bars.exP;
        curXP = bars.curXp;

        //x = checkPoint.curCheckPoint.position.x;
        //y = checkPoint.curCheckPoint.position.y;
        //z = checkPoint.curCheckPoint.position.z;
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        rx = transform.eulerAngles.x;
        ry = transform.eulerAngles.y;
        rz = transform.eulerAngles.z;




        Save.SaveData(this);
    }

    

    public void LoadData()
    {
        // referencing Data script and then the save script's public state function
        Data data = Save.LoadData(this); // this is giving all the data.variable values in its return callback. 
        //Data data stores all the references for data.variables as a class

        level = data.level;
        name = data.playerName;
        curHP = data.curHP;
        maxHP = data.maxHP;
        health.maxHealth = maxHP;
        health.curHealth = curHP;
        bars.maxMana = maxMP;
        bars.curMana = curMP;
        bars.curStam = curStam;
        bars.maxStam = maxStam;
        bars.exP = exp;
        bars.curXp = curXP;


        x = data.x;
        y = data.y;
        z = data.z;
        rx = data.rx;
        ry = data.ry;
        rz = data.rz;
        this.transform.position = new Vector3(x, y, z);

    }

    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {

        SaveFunction();
        if (Input.GetKeyDown(KeyCode.F12))
        {
            //SaveFunction();
            Debug.Log("Saved");
        }
        

        if (Input.GetKeyDown(KeyCode.F10))
        {

            LoadData();
        }
    }
}
