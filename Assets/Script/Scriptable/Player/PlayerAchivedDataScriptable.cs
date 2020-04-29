using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerAchivedDataScriptable : ScriptableObject
{
    public List<GameEnum.PlayerrTType> achievedPlayerShipList;
    public List<GameEnum.GunType> gunsList;
    public List<GameEnum.CollectableType> collectableList;
    public int maxLevelCompletedByPlayer = 1;
}


