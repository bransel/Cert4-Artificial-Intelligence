using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//you will need to change Scenes
public class CustomisationSet : MonoBehaviour {

    #region Variables
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int hairIndex, mouthIndex, eyesIndex, armourIndex, clothesIndex;

    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;

    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int hairMax, mouthMax, eyesMax, armourMax, clothesMax;

    [Header("Character Name")]
    //name of our character that the user is making
    public string charName = "Adventurer";

    [Header("Stats")]
    //Class 
    public CharacterClass characterClass;
    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] tempStats = new int[6];
    public int points = 10;
    public string[] selectedClass = new string[4];
    public int selectedIndex = 0;


    #endregion

    #region Start
    //in start we need to set up the following
    private void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Warrior", "Mage", "Cleric", "Rogue" };
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of hair textures we need
        //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
        for (int i = 0; i < hairMax; i++)
        {

            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;

            hair.Add(temp);
        }
        //add our temp texture that we just found to the hair List


        //for loop looping from 0 to less than the max amount of mouth textures we need    


        //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#

        //add our temp texture that we just found to the mouth List
        for (int i = 0; i < mouthMax; i++)
        {

            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;

            mouth.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of eyes textures we need
        //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
        //add our temp texture that we just found to the eyes List            

        for (int i = 0; i < eyesMax; i++)
        {

            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;

            eyes.Add(temp);
        }

        for (int i = 0; i < armourMax; i++)
        {

            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;

            armour.Add(temp);
        }
        for (int i = 0; i < clothesMax; i++)
        {

            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;

            clothes.Add(temp);
        }
        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        SetTexture("Skin", skinIndex= 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);

        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        #endregion


    }

    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    //we need variables that exist only within this function
    //these are ints index numbers, max numbers, material index and Texture2D array of textures
    //inside a switch statement that is swapped by the string name of our material
    void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        #region Switch Material

        //case skin
        //index is the same as our skin index
        //max is the same as our skin max
        //textures is our skin list .ToArray()
        //material index element number is 1
        //break
        //now repeat for each material 
        //hair is 2
        //index is the same as our index
        //max is the same as our max
        //textures is our list .ToArray()
        //material index element number is 2
        //break
        //mouth is 3
        //index is the same as our index
        //max is the same as our max
        //textures is our list .ToArray()
        //material index element number is 3
        //break
        //eyes are 4
        //index is the same as our index
        //max is the same as our max
        //textures is our list .ToArray()
        //material index element number is 4
        //break
        switch (type)
        {

            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 6;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 5;
                break;
                #endregion
        }
        #region OutSide Switch
        index += dir;
        if(index<0)
        { index = max - 1; }

        if (index > max -1)
        {
            index = 0;
        }
       
            Material[] mat = character.materials;
        mat[matIndex].mainTexture = textures[index];
        character.materials = mat;
        //outside our switch statement
        //index plus equals our direction
        //cap our index to loop back around if is is below 0 or above max take one
        //Material array is equal to our characters material list
        //our material arrays current material index's main texture is equal to our texture arrays current index
        //our characters materials are equal to the material array
        //create another switch that is goverened by the same string name of our material
        #endregion

        #region Set Material Switch
        switch(type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;

            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;




        }
        //case skin
        //skin index equals our index
        //break
        //case hair
        //index equals our index
        //break
        //case mouth
        //index equals our index
        //break
        //case eyes
        //index equals our index
        //break
        #endregion
        #endregion


    }




    #region Save

    void Save()//Function called Save this will allow us to save our indexes 
    //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
    //SetString CharacterName
    {
        
    }

    #endregion

    #region OnGUI
    //Function for our GUI elements
    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        int i = 0; 
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i*(0.5f*scrH), 0.5f * scrW, 0.5f* scrH), "<"))
        {
            SetTexture("Skin", -1);

        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW,  0.5f * scrH), "Skin");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Skin", 1);

        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Hair", -1);

        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Hair");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Hair", 1);

        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Eyes", -1);

        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Eyes");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Eyes", 1);

        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Mouth", -1);

        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Mouth");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Mouth", 1);

        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Clothes", -1);

        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Clothes");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Clothes", 1);

        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Armour", -1);

        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Armour");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Armour", 1);

        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),  scrW, 0.5f * scrH), "Reset"))
        {
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
            SetTexture("Armour", armourIndex = 0);

        }
        if (GUI.Button(new Rect(1.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Random"))
        {

            SetTexture("Skin", Random.Range(0, skinMax-1));
            SetTexture("Hair", Random.Range(0, hairMax -1));
            SetTexture("Mouth", Random.Range(0, mouthMax - 1));
            SetTexture("Eyes", Random.Range(0, eyesMax - 1));
            SetTexture("Clothes", Random.Range(0, clothesMax - 1));
            SetTexture("Armour", Random.Range(0, armourMax - 1));
        }

    }
    //create the floats scrW and scrH that govern our 16:9 ratio
    //create an int that will help with shuffling your GUI elements under eachother
    #region Skin
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence Skin
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    //set up same things for Hair, Mouth and Eyes
    #region Hair
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Mouth
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Eyes
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Random Reset
    //create 2 buttons one Random and one Reset
    //Random will feed a random amount to the direction 
    //reset will set all to 0 both use SetTexture
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Character Name and Save & Play
    //name of our character equals a GUI TextField that holds our character name and limit of characters
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this

    //GUI Button called Save and Play
    //this button will run the save function and also load into the game level
    #endregion
    #endregion

    public enum CharacterClass
    {
        Warrior, Mage, Cleric, Rogue
    }
}
