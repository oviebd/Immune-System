using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerAchivedDataScriptable : ScriptableObject
{
    public List<GameEnum.PlayerType> playersList;
    public List<GameEnum.GunType> gunsList;
}
