using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    public static PlayerSpawnerController instance;

    [SerializeField] private GameEnum.PlayerrTType _currentPlayerType;

    [SerializeField] private List<PlayerController> _playerList;
    [SerializeField] private GameObject _gunPrefab; 


  //  PlayerLevelData data;

    PlayerController currentPlayerController;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void LoadPlayer()
    {
		_currentPlayerType = GameDataHandler.instance.GetCurrentPlayer();
        GameObject playerPrefab = GetSpecificPlayerControllerBasedOnType(_currentPlayerType);
        if (playerPrefab != null)
        {
            GameObject playerObj = InstantiatorHelper.instance.InstantiateObject(playerPrefab);
            currentPlayerController = playerObj.GetComponent<PlayerController>();

            if (currentPlayerController != null){
               // currentPlayerController.SetPlayerLevelData(data);
                currentPlayerController.InstantiateGun(_gunPrefab);
            }
        }
    }

    GameObject GetSpecificPlayerControllerBasedOnType(GameEnum.PlayerrTType type)
    {
        for (int i = 0; i < _playerList.Count; i++)
        {
            if (type == _playerList[i].GetPlayerType())
            {
                return _playerList[i].gameObject;
            }
        }
        return null;
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
