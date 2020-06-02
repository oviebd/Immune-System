using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHandler 
{
    public static string CreateJson(object data)
    {
        string json = JsonUtility.ToJson(data);
        return json;
    }


    public static T DeserializeJson<T>(string data)
    {
        T myObject = JsonUtility.FromJson<T>(data);
        return myObject;
    }
}
