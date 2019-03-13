using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour {


    #region Key Variables for the player
    //health, level, exp, mana, stamina, position, name, customisation etc.
    public int level;
    // new name specifically to do with this script, new keyword?
    public new string name;
    public float maxHP;
    public float curHP;
    //reference to the Healthbar script, and giving it a reference health for this script.
    public HealthBar health;

    #endregion
    // Use this for initialization
   public void SaveFunction()
    {
        // making sure our variable maxHP lines up with health script's Maxhealth variable and also curhealth before we save
        maxHP = health.maxHealth;
        curHP = health.curHealth;
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

    }

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            SaveFunction();
            Debug.Log("Saved" + name);
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            
            LoadData();
        }
    }
}
