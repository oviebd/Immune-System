﻿using System.Collections;
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

    public static IMove[]  GetAllIMoveComponentsFromAGameObject( GameObject gameObj)
    {
       IMove[] moves = gameObj.GetComponents<IMove>();
        return moves;
    }
    public static void StopMovementOf_A_IMove_Gameobject(GameObject gameObj)
    {
        IMove[] moves = GetAllIMoveComponentsFromAGameObject(gameObj);
        if(moves != null )
        {
            for (int i = 0; i < moves.Length; i++)
            {
                moves[i].StopMovement();
            }
        }
    }

	public static void StartMovementOf_A_IMove_Gameobject(GameObject gameObj)
	{
		IMove[] moves = GetAllIMoveComponentsFromAGameObject(gameObj);
		if (moves != null)
		{
			for (int i = 0; i < moves.Length; i++)
			{
				moves[i].Run();
			}
		}
	}

	public static bool CanSpawnThings()
    {
        if (GameManager.instance.GetCurrentGameState() == GameEnum.GameState.Running)
            return true;
        else
            return false;
    }

    public  static string GetPlayerShortDescription(GameEnum.PlayerType type)
    {
        string description = "";

        switch (type)
        {
            case GameEnum.PlayerType.Type_1_Base:
                description = "Base Player";
                break;
            case GameEnum.PlayerType.Type_2_Dozzer:
                description = "Speedy But has low health";
                break;
            case GameEnum.PlayerType.Type_3_Healthy:
                description = "More Health But slow movement";
                break;
            case GameEnum.PlayerType.Type_4_Shooter:
                description = "High Fire power with low health";
                break;
        }
        return description;
    }
   
}
