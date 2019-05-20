using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//you will need to change Scenes
public class CustomisationGet : MonoBehaviour {

    [Header("Character")]
    //public variable for the Skinned Mesh Renderer which is our character reference
    public Renderer character;

    #region Start
    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<SkinnedMeshRenderer>();
        
    }


    //our character reference connected to the Skinned Mesh Renderer via finding the Mesh
    //Run the function LoadTexture	
    #endregion

    #region LoadTexture Function

        public static WarriorData LoadData()
    {
        {
            string path = Application.persistentDataPath + "/save";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                WarriorData data = formatter.Deserialize(stream) as WarriorData;
                stream.Close();

                return data;

            }
            else
            {

            }
        }
    }
   public void LoadTexture(CustomisationSet custom) {


        //check to see if our save file for this character
        //if it doesnt then load the CustomSet level
        //if it does have a save file then load and SetTexture Skin, Hair, Mouth and Eyes 
        //grab the gameObject in scene that is our character and set its Object name to the Characters name
       
       

    }
    #endregion
    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    void SetTexture(string type, int index)
    {
        //the string is the name of the material we are editing, the int is the direction we are changing
        //we need variables that exist only within this function
        //these are int material index and Texture2D array of textures
       

        Texture2D tex = null;
        int matIndex = 0;
        //inside a switch statement that is swapped by the string name of our material
        //case skin      
        switch (type)
        {
            case "Skin":  //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Skin_" + index) as Texture2D;
                //material index element number is 1
                matIndex = 1;
                //break
                break;

            case "Hair":
                tex = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 4;
                break;
            case "mouth":
                tex = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex = 3;
                break;
            case "eyes":
                tex = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 3;
                break;
            case "Armour":
                tex = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 5;
                break;

            case "Clothes":
                tex = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 6;
                break;

                //Material array is equal to our characters material list
                Material[] mats = character.materials;
                //our material arrays current material index's main texture is equal to our texture arrays current index
                mats[matIndex].mainTexture = tex;
                //our characters materials are equal to the material array
                character.materials = mats; 

        }


    }







    //now repeat for each material 
    //hair is 2
    //mouth is 3
    //eyes are 4


    #endregion
    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + 10 * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Load"))
        {
            LoadTexture();
        }

    }
}
