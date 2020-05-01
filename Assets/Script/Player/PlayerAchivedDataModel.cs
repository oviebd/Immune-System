using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAchivedDataModel
{
	public List<GameEnum.PlayerrTType> playerShipList;
	public List<GameEnum.GunType> gunsList;
	public List<GameEnum.CollectableType> collectableList;
	public int maxLevelCompletedByPlayer = 1;
	public int totalScore = 0;
}
