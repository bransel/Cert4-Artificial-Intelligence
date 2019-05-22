﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();

    public static bool showInv;
    public Item selectedItem;
    public static int money;

    // Movement.canMove

    public Vector2 scr;//
    public Vector2 scrollPos; // scroll bar
    public string[] sortType = new string[7];
    public int index;

    public string sortingType = "All";

    public Transform dropLocation;
    public Transform[] equippedLocation;

    /*
    
    0 = right hand
    1= head

    
     */
    public GameObject curWeapon;
    public GameObject curHelm;


    #endregion

    private void Start()
    {

        sortType = new string[] {"All","Consumable", "Weapon", "Apparel", "Quest"

        };
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(302));
        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);

        }


    }

    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
            return false;
        }
        else
        {
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.canMove = false;
            return true;
        }

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //if(!PauseMenu.isPaused)
            ToggleInv();
        }
    }

    #region Types
    void DisplayInv(string sortType)
    {
        if (!(sortType == "All" || sortType == ""))
        {
            // then covert the sortType to our ItemType
            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
            int a = 0; // amount of that type
            int s = 0; // slot position of GUI item
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type) // if inventory item = type declared
                {
                    a++; // increase the amount of this type

                }
            }

            if (a <= 34) // if the amount of this type is less than or equal to the amount we can display on the screen without scrolling
            {
                for (int i = 0; i < inv.Count; i++) // filter through all items
                {
                    if (inv[i].Type == type) //if its the type we want to display
                    {
                        //we display a button that is of this type and slot htem under the last one 

                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        s++;
                        //increase the slot position , so the next one slides under 

                    }
                }
            }
            else //if more than amount of viewable items
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((a - 34) * (0.25f * scr.y))), false, true);

                #region Items in Viewing Area
                {
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (inv[i].Type == type)
                        {
                            if (inv[i].Type == type) //if its the type we want to display
                            {
                                //we display a button that is of this type and slot htem under the last one 

                                if (GUI.Button(new Rect(0 * scr.x, 0 * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                                {
                                    selectedItem = inv[i];
                                    Debug.Log(selectedItem.Name);
                                }
                            }
                        }
                    }
                }
            }
        }
        else

        {
            scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);

            #region Items in Viewing Area
            {
                for (int i = 0; i < inv.Count; i++)
                {


                    if (GUI.Button(new Rect(0 * scr.x, 0 * scr.y + i* (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }


                }
            }
        }

        #endregion

        GUI.EndScrollView();




#endregion
        



    }
    private void OnGUI()
    {
        // if(!PauseMenu.paused)
        if (showInv)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            for (int i = 0; i <sortType.Length; i++)
            {
                if (GUI.Button(new Rect(5.5f * scr.x + i * (scr.x), 0.25f * scr.y, scr.x, 0.25f * scr.y), sortType[i]))
                {
                    sortingType = sortType[i];
                }
            }

            DisplayInv(sortingType);
            if(selectedItem != null)
            {
                GUI.DrawTexture(new Rect(11*scr.x, 1.5f*scr.y, 2*scr.x, 2*scr.y), selectedItem.Icon);

            }
        }

    }
    #endregion
}