using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save
//calling it static means we can reference it from anywhere
{

    public static void SaveData(PlayerGame player) // Playergame script that we access and save, and player is our reference, player can be anything
    {
        // binary formatter 
        
        BinaryFormatter formatter = new BinaryFormatter();
        // save path or create a path name for the save
        string path = Application.persistentDataPath + "/" + player.name + "";
        // file stream ??
        FileStream stream = new FileStream(path, FileMode.Create);
        //data = player's data as data's data
        Data data = new Data(player);

        // convert to binary and save to path;
        formatter.Serialize(stream, data);

        //end
        stream.Close();

    }

    public static Data LoadData(PlayerGame player) // is this where the player reference exists and why we need it in our public int
    // we're returning a Data
    {
        // have a path , referencing the public string from PlayerGame 
        string path = Application.persistentDataPath + "/" + player.name + "";

        // check to see if the path exists
        if (File.Exists(path))
        { // formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // stream open 
            FileStream stream = new FileStream(path, FileMode.Open);
            // data deserialize
            Data data = formatter.Deserialize(stream) as Data;
            // end
            stream.Close();
            // return, getting the data numbers 

            return data;
        
        }


        //else
        else
        {
            //debug error
            Debug.Log("No Path Found");

            //return null
            return null;
        }
    }
      

}