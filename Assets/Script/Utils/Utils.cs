using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{

    public static bool IsItMobilePlatform()
    {
        bool isItMobilePlatform = false;

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            isItMobilePlatform = true;
        }
        return isItMobilePlatform;
    }
}
