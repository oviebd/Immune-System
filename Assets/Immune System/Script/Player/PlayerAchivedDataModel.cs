using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAchivedDataModel
{
	public List<GameEnum.PlayerType> playerShipList = new List<GameEnum.PlayerType>();
	public List<GameEnum.GunType> gunsList = new List<GameEnum.GunType>();
	public List<GameEnum.CollectableType> collectableList = new List<GameEnum.CollectableType>();
	public int maxLevelCompletedByPlayer = 1;
	public int totalScore = 0;
}
