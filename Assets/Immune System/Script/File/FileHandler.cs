using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileHandler 
{

    public static bool IsFileExist(string path)
    {
        return File.Exists(path);
    }

    public static void CreateFileInAPath(string path)
    {
        if(IsFileExist(path) == false)
            File.Create(path).Dispose();
    }

    public static string CreatePersistantFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

    public static void WriteInFile(string filePath, string content)
    {
        CreateFileInAPath(filePath);
        if (IsFileExist(filePath) == true)
        {
            File.WriteAllText(filePath, content);
        }
    }
    public static string ReadText(string filePath)
    {
        string content = "";

        if (IsFileExist(filePath) == true)
            content = File.ReadAllText(filePath);
        return content;
    }

}
