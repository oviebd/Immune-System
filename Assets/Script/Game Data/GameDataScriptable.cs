using UnityEngine;

[CreateAssetMenu]
public class GameDataScriptable : ScriptableObject
{
    public int  currentLevel = 1;
    public bool isGameFirstTimeLaunched = true;
    public bool isTutorialShown = false;
    public bool isSoundOn = true;
	public GameEnum.PlayerrTType currentPlayer;
}
