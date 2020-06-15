using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataHandler : MonoBehaviour
{
    public static GameDataHandler instance;

   // [SerializeField] private GameDataScriptable _gameDataScriptable;
    [SerializeField] private int _maxLevelnumber = 2;

	public delegate void OnCurrentPlayerChange(GameEnum.PlayerType playerType);
	public static event OnCurrentPlayerChange onCurrentPlayerChange;

	public delegate void OnGameLevelChange(int currentLevel);
	public static event OnGameLevelChange onGameLevelChange;

    private string _gameDataFileName = "GameData.json";
    private string _filePath;

	private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private string GetFilePath()
    {
        return FileHandler.CreatePersistantFilePath(_gameDataFileName);
    }

    public int getMaxLevelNumber()
    {
        return _maxLevelnumber;
    }
    public int GetCurrentLevelNumber()
    {
        return GetGameData().currentLevel;
    }
	public GameEnum.PlayerType GetCurrentPlayer()
	{
		return GetGameData().currentPlayer;
	}
	public void SetCurrentPlayer(GameEnum.PlayerType playerType)
	{
		GameDataModel data = GetGameData();
		data.currentPlayer = playerType;
		SetGameData(data);

		if(onCurrentPlayerChange !=null)
			onCurrentPlayerChange(playerType);
	}

	public void SetCurrentLevelNumber(int levelNumber)
    {
        GameDataModel data = GetGameData();
        data.currentLevel = levelNumber;
        SetGameData(data);
		if(onGameLevelChange !=null)
			onGameLevelChange(levelNumber);
	}

    public void SetGameData(GameDataModel data)
    {
        string jsonString = JsonHandler.CreateJson(data);
        FileHandler.WriteInFile(GetFilePath(), jsonString);
    }

    public GameDataModel GetGameData()
    {
        GameDataModel data = new GameDataModel();

        if( FileHandler.IsFileExist(GetFilePath()) == true)
        {
            string content = FileHandler.ReadText(GetFilePath());
            data = JsonHandler.DeserializeJson<GameDataModel>(content);
            if(data == null)
                return new GameDataModel();
        }
        return data;
    }

}
