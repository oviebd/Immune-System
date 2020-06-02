using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataModel 
{
    public int currentLevel = 1;
    public bool isGameFirstTimeLaunched = true;
    public bool isTutorialShown = false;
    public bool isSoundOn = true;
	public GameEnum.PlayerType currentPlayer;
}
