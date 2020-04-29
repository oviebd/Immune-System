using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataCreator 
{
   /* public static LevelRequiredDataModel GetLevelRequiredDataModel(int levelNumber)
    {
        LevelRequiredDataModel data = new LevelRequiredDataModel();
        PlayerLevelData playerLevelData = LevelDataHandler.instance.GetPlayerLevelData(levelNumber);

        if (playerLevelData == null)
            return data;

        data.LevelNumber = levelNumber;

        if (playerLevelData.playerPrefab.GetComponent<PlayerController>() != null)
            data.shipType = playerLevelData.playerPrefab.GetComponent<PlayerController>().GetPlayerType();

        if (playerLevelData.playerGunPrefab.GetComponent<GunBase>() != null)
            data.gunType = playerLevelData.playerGunPrefab.GetComponent<GunBase>().GetGun();
        return data;
    }*/
}
