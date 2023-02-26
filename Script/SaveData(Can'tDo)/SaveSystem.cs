using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveHighScore(int highscore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscore.nani";
        FileStream stream = new FileStream(path, FileMode.Create);

        int data = highscore;

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static int LoadHighScore()
    {
        string path = Application.persistentDataPath + "highscore.nani";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            int highscore = (int)formatter.Deserialize(stream);
            stream.Close();

            return highscore;
        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            return 0;
        }
    }
}
