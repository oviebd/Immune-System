using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAchivedDataHandler : MonoBehaviour
{
    public static PlayerAchivedDataHandler instance;
    [SerializeField] private PlayerAchivedDataScriptable _playerAchivedDatScriptable;

	private PlayerAchivedDataModel _achievedDataModel;

	public delegate void OnTotalScoreChanged();
	public static event OnTotalScoreChanged onTotalScoreChange;

	private void Awake()
    {
        if (instance == null)
            instance = this;
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
		if(data != null)
		{
			_playerAchivedDatScriptable.playerShipList = data.playerShipList;
			_playerAchivedDatScriptable.gunsList = data.gunsList;
			_playerAchivedDatScriptable.maxLevelCompletedByPlayer = data.maxLevelCompletedByPlayer;
			_playerAchivedDatScriptable.totalScore = data.totalScore;
			_playerAchivedDatScriptable.collectableList = data.collectableList;
		}
	}
	private PlayerAchivedDataModel GetPlayerAchivedData()
	{
		PlayerAchivedDataModel data = new PlayerAchivedDataModel();
		if(_playerAchivedDatScriptable != null)
		{
			data.playerShipList = _playerAchivedDatScriptable.playerShipList;
			data.gunsList = _playerAchivedDatScriptable.gunsList;
			data.maxLevelCompletedByPlayer = _playerAchivedDatScriptable.maxLevelCompletedByPlayer;
			data.totalScore = _playerAchivedDatScriptable.totalScore;
			data.collectableList = _playerAchivedDatScriptable.collectableList;
		}
		return data;
	}
	#endregion Common
}
