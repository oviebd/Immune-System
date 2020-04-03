using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    public static PlayerSpawnerController instance;
    PlayerLevelData data;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

   public void LoadLevelPlayerData(int levelNumber)
    {
        data = LevelDataHandler.instance.GetPlayerLevelData(levelNumber);
        if (data != null)
        {
            GameObject playerObj = InstantiatorHelper.InstantiateObject(data.playerPrefab, this.transform.gameObject);
            PlayerController playerController = playerObj.GetComponent<PlayerController>();

            if (playerController != null){
                playerController.SetPlayerLevelData(data);
                playerController.InstantiateGun(data.playerGunPrefab);
            }
            
        }
    } 
    
}
