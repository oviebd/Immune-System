using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    public static PlayerSpawnerController instance;

    [SerializeField] private GameEnum.PlayerType _currentPlayerType;
    [SerializeField] private List<PlayerController> _playerList;
    [SerializeField] private GameObject _gunPrefab; 

    private PlayerController _currentGamePlayerController;
    private PlayerController _currentTutorialPlayerController;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private PlayerController InstantiatePlayer()
    {
		_currentPlayerType = GameDataHandler.instance.GetCurrentPlayer();
        GameObject playerPrefab = GetSpecificPlayerBasedOnType(_currentPlayerType);
        if (playerPrefab != null)
        {
            GameObject playerObj = InstantiatorHelper.instance.InstantiateObject(playerPrefab);
            return playerObj.GetComponent<PlayerController>();
        }
        return null;
    }

    public void LoadPlayerForGame()
    {
       PlayerController controller = InstantiatePlayer();
        if (controller != null)
            _currentGamePlayerController = controller;
    }

    public void LoadPlayerForTutorial()
    {
        PlayerController controller = InstantiatePlayer();
        if (controller != null)
		{
			_currentTutorialPlayerController = controller;
			Vector2 pos = controller.gameObject.transform.position;
			controller.gameObject.transform.position = new Vector3(pos.x + 4.0f, pos.y + 2.0f);
		}
          
    }
    public GameObject GetSpecificPlayerBasedOnType(GameEnum.PlayerType type)
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


    public PlayerController GetCurrentGamePlayerController()
    {
        return _currentGamePlayerController;
    }
    public PlayerController GetCurrentTutorialPlayerController()
    {
        return _currentTutorialPlayerController;
    }

    public void HidePlayer()
    {
        if (_currentGamePlayerController != null)
            _currentGamePlayerController.gameObject.SetActive(false);
    }
    public void ShowPlayer()
    {
        if (_currentGamePlayerController != null)
            _currentGamePlayerController.gameObject.SetActive(true);
    }

}
