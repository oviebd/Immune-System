﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerAchivedDataScriptable : ScriptableObject
{
    public List<GameEnum.PlayerShipType> achievedPlayerShipList;
    public List<GameEnum.GunType> gunsList;
    public int maxLevelCompletedByPlayer = 1;
}


