using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataHandler : MonoBehaviour
{
    public static GameDataHandler instance;

    [SerializeField] private GameDataScriptable _gameDataScriptable;
    [SerializeField] private int _maxLevelnumber = 2;

   private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public int getMaxLevelNumber()
    {
        return _maxLevelnumber;
    }
    public int GetCurrentLevelNumber()
    {
        return GetGameData().currentLevel;
    }
	public GameEnum.PlayerrTType GetCurrentPlayer()
	{
		return GetGameData().currentPlayer;
	}
	public void SetCurrentPlayer(GameEnum.PlayerrTType playerType)
	{
		GameDataModel data = GetGameData();
		data.currentPlayer = playerType;
		SetGameData(data);
	}

	public void SetCurrentLevelNumber(int levelNumber)
    {
        GameDataModel data = GetGameData();
        data.currentLevel = levelNumber;
        SetGameData(data);
    }

    public void SetGameData(GameDataModel data)
    {
        if (_gameDataScriptable != null && data != null)
        {
            _gameDataScriptable.currentLevel = data.currentLevel;
            _gameDataScriptable.isGameFirstTimeLaunched = data.isGameFirstTimeLaunched;
            _gameDataScriptable.isTutorialShown = data.isTutorialShown;
            _gameDataScriptable.isSoundOn = data.isSoundOn;
			_gameDataScriptable.currentPlayer = data.currentPlayer;
        }
    }

    public GameDataModel GetGameData()
    {
        GameDataModel data = new GameDataModel();
        if (_gameDataScriptable != null)
        {
            data.currentLevel = _gameDataScriptable.currentLevel;
            data.isGameFirstTimeLaunched = _gameDataScriptable.isGameFirstTimeLaunched;
            data.isTutorialShown = _gameDataScriptable.isTutorialShown;
            data.isSoundOn = _gameDataScriptable.isSoundOn;
			data.currentPlayer = _gameDataScriptable.currentPlayer;
        }
        return data;
    }

}
