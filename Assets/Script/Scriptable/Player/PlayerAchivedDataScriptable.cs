using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerAchivedDataScriptable : ScriptableObject
{
    public List<GameEnum.PlayerType> playerShipList;
    public List<GameEnum.GunType> gunsList;
    public List<GameEnum.CollectableType> collectableList;
    public int maxLevelCompletedByPlayer = 1;
	public int totalScore = 0;
}


