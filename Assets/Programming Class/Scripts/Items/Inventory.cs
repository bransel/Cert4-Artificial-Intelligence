using System.Collections;
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

    public HealthBar health;
    public Transform[] equippedLocations;
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

    void Update()
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
        //if we pick a type
        if (!(sortType == "All" || sortType == ""))
        {
            //then convert the sortType to our ItemType

            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
            int a = 0;//amount of that type
            int s = 0;//slot position of item
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type)//find our types
                {
                    a++;//increase the amount of this type
                }
            }
            if (a <= 34)//if the amount of this type is less or equal to the amount we can display on screen without scrolling 
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)//if its the type we want to display
                    {
                        //we display a button that is of this type and slot them under the last one

                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];//select the time from its position in the inventory
                            Debug.Log(selectedItem.Name);
                        }
                        s++;//increase the slot pos so the next one slides under
                    }
                }
            }
            else//if more than amount of viewable items
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((a - 34) * (0.25f * scr.y))), false, true);
                #region Items in Viewing Area
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0, s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];//select the time from its position in the inventory
                            Debug.Log(selectedItem.Name);
                        }
                        s++;//increase the slot pos so the next one slides under
                    }
                }
                #endregion
                GUI.EndScrollView();
            }
        }
        //if we are viewing All
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);
                #region Items in Viewing Area
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0 * scr.x, 0 * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];//select the time from its position in the inventory
                        Debug.Log(selectedItem.Name);
                    }
                }
                #endregion
                GUI.EndScrollView();
            }
        }
    }

    void DisplayItem()
    {
        switch (selectedItem.Type)
        {

        case ItemType.Consumable:
            GUI.Box(new Rect(8*scr.x, 5* scr.y, 8* scr.x, 3* scr.y),selectedItem.Name+"\n" + selectedItem.Description + "\nValue:" + selectedItem.Value + "\n"+ "\nHeal" + selectedItem.Heal + "\nAmount:" + selectedItem.Amount );
                    if (health.curHealth < health.maxHealth)
                    {
                        if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                        {
                            health.curHealth += selectedItem.Heal;
                            DepleteAmount();
                        }

                    }
                    if (GUI.Button(new Rect(14 * scr.x, 8.75f* scr.y, scr.x, 0.25f* scr.y), "Discard"))
                    {
                        Discard();
                    }

            break;

        case ItemType.Apparel:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue:" + selectedItem.Value + "\n" + "\nArmour" + selectedItem.Armour + "\nAmount:" + selectedItem.Amount);
                if (curHelm == null || selectedItem.Mesh.name != curHelm.name)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                    {
                        if (curHelm != null)
                        {
                            Destroy(curHelm);
                        }
                        curHelm = Instantiate(selectedItem.Mesh, equippedLocations[1]);
                        if (curHelm.GetComponent<ItemHandler>() != null)
                        {
                            curHelm.GetComponent<ItemHandler>().enabled = false;
                        }
                        curHelm.name = selectedItem.Mesh.name;
                    }

                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {

                    if (curHelm != null && selectedItem.Mesh.name == curHelm.name)
                    {
                        Destroy(curHelm);
                    }
                    Discard();
                }
                    break;



        case ItemType.Weapon:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue:" + selectedItem.Value + "\n" + "\nDamage" + selectedItem.Damage + "\nAmount:" + selectedItem.Amount);
                if(curWeapon == null || selectedItem.Mesh.name != curWeapon.name)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                    {
                        if (curWeapon != null)
                        {
                            Destroy(curWeapon);
                        }
                        curWeapon = Instantiate(selectedItem.Mesh, equippedLocations[0]);
                        if (curWeapon.GetComponent<ItemHandler>() != null)
                        {
                            curWeapon.GetComponent<ItemHandler>().enabled = false;
                        }
                        curWeapon.name = selectedItem.Mesh.name;
                    }
                    
                }
                
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {

                    if(curWeapon != null && selectedItem.Mesh.name == curWeapon.name)
                    {
                        Destroy(curWeapon);
                    }
                    Discard();
                }
                break;

        case ItemType.Quest:
            break;

        default:
            break;
         }

    }

        void DepleteAmount()
        {
            if (selectedItem.Amount > 1)
            {
                selectedItem.Amount--;
            }
            else
            {

                inv.Remove(selectedItem);
                selectedItem = null;
            }
            return;
        }
    void Discard()
    {
          GameObject clone =  Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
        clone.AddComponent<Rigidbody>().useGravity = true;
        DepleteAmount();
    }
    void OnGUI()
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
                DisplayItem();
            }
          
        }

    }
    #endregion
}