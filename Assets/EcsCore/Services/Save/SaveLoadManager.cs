using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveLoadManager
{
    public static void Save(object obj, string filename)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = null;

        try
        {
            //string filePath = Application.persistentDataPath + "/" + filename;
            string filePath = Application.dataPath + "/Resources/" + filename;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            fileStream = File.Create(filePath);
            binaryFormatter.Serialize(fileStream, obj);
        }
        catch (Exception e)
        {
            Debug.Log("An error occurred: " + e.Message);
        }
        finally
        {
            if (fileStream != null)
            {
                fileStream.Close();
            }
        }
    }

    public static T Load<T>(string filename)
    {
        //if (File.Exists(Application.persistentDataPath + "/" + filename))
        if (File.Exists(Application.dataPath + "/Resources/" + filename))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            //FileStream fileStream = File.Open(Application.persistentDataPath + "/" + filename, FileMode.Open);
            FileStream fileStream = File.Open(Application.dataPath + "/Resources/" + filename, FileMode.Open);

            T obj = (T)binaryFormatter.Deserialize(fileStream);

            fileStream.Close();

            return obj;
        }
        else
        {
            return default(T);
        }
    }
}
