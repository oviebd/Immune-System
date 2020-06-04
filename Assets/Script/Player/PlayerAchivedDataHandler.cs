using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAchivedDataHandler : MonoBehaviour
{
    public static PlayerAchivedDataHandler instance;

	public delegate void OnTotalScoreChanged();
	public static event OnTotalScoreChanged onTotalScoreChange;

	private string _fileName = "PlayerAchicedData.json";

	private void Awake()
    {
        if (instance == null)
            instance = this;
    }

	private string GetFilePath()
	{
		return FileHandler.CreatePersistantFilePath(_fileName);
	}

	#region TotalScore
	public int GetTotalScore()
	{
		return GetPlayerAchivedData().totalScore;
	}

	public void SetTotalScore(int totalScore)
	{
		PlayerAchivedDataModel data = GetPlayerAchivedData();
		data.totalScore = totalScore;
		SetPlayerAchivedData(data);
		if(onTotalScoreChange != null)
			onTotalScoreChange();

	}
	#endregion TotalScore

	#region MaxCompletedLevel
	public int GetMaxCompletedLevelNumber()
    {
		return GetPlayerAchivedData().maxLevelCompletedByPlayer;
    }
    public void SetMaxCompletedLevelNumber(int levelNumber)
    {
		if (levelNumber >= GetMaxCompletedLevelNumber())
		{
			PlayerAchivedDataModel data =GetPlayerAchivedData() ;
			data.maxLevelCompletedByPlayer = levelNumber;
			SetPlayerAchivedData(data);
		}	
	}
	#endregion MaxCompletedLevel

	#region Ship
	public void InsertPlayerShipInAchivedList(GameEnum.PlayerType type)
	{
		if (IsThisPlayerShipAlreadyPurchasedByPlayer(type) == false)
		{
			PlayerAchivedDataModel data = GetPlayerAchivedData();
			data.playerShipList.Add(type);
			SetPlayerAchivedData(data);
		}
	}
	public bool IsThisPlayerShipAlreadyPurchasedByPlayer(GameEnum.PlayerType type)
	{
		if (GetPlayerAchivedData().playerShipList.Contains(type) == true)
			return true;
		return false;
	}
	#endregion Ship

	#region Collectable
	public void AddCollectableInPlayerAchivedData(GameEnum.CollectableType type)
    {
		if (IsThisCollectableAlreadyConsumedByPlayer(type) == false)
		{
			PlayerAchivedDataModel data = GetPlayerAchivedData();
			data.collectableList.Add(type);
			SetPlayerAchivedData(data);
		}
    }
    public bool IsThisCollectableAlreadyConsumedByPlayer(GameEnum.CollectableType type)
    {
		if (GetPlayerAchivedData().collectableList.Contains(type) == true)
            return true;
		return false;
    }
	#endregion Collectable

	#region Common

    private void SetPlayerAchivedData(PlayerAchivedDataModel data)
	{
		string jsonString = JsonHandler.CreateJson(data);
		FileHandler.WriteInFile(GetFilePath(), jsonString);
	}

    private PlayerAchivedDataModel GetPlayerAchivedData()
	{
		PlayerAchivedDataModel data = GetInitialPlayerAchivedDataModel();
        if (FileHandler.IsFileExist(GetFilePath()) == true)
		{
			string content = FileHandler.ReadText(GetFilePath());
			data = JsonHandler.DeserializeJson<PlayerAchivedDataModel>(content);
			if (data == null)
				return GetInitialPlayerAchivedDataModel();
		}
		return data;
	}

	#endregion Common

    private PlayerAchivedDataModel GetInitialPlayerAchivedDataModel()
    {
		PlayerAchivedDataModel data = new PlayerAchivedDataModel();
		data.playerShipList.Add(GameEnum.PlayerType.Type_1_Base);
		data.gunsList.Add(GameEnum.GunType.GunType_1);
		data.totalScore = 0;
		return data;
	}
}
