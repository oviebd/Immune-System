using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    public static PlayerSpawnerController instance;
    PlayerLevelData data;

    PlayerController currentPlayerController;

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
            GameObject playerObj = InstantiatorHelper.instance.InstantiateObject(data.playerPrefab);
            currentPlayerController = playerObj.GetComponent<PlayerController>();

            if (currentPlayerController != null){
                currentPlayerController.SetPlayerLevelData(data);
                currentPlayerController.InstantiateGun(data.playerGunPrefab);
            }
            
        }
    }

    public PlayerController GetCurrentPlayerController()
    {
        return currentPlayerController;
    }

    public void HidePlayer()
    {
        if (currentPlayerController != null)
            currentPlayerController.gameObject.SetActive(false);
    }
    public void ShowPlayer()
    {
        if (currentPlayerController != null)
            currentPlayerController.gameObject.SetActive(true);
    }

}
