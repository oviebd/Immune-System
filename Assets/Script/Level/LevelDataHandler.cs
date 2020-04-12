using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{
    public static LevelDataHandler instance;
    
    [SerializeField] private List<EnemyLevelDataScriptable> _levelDataListEnemy ;
    [SerializeField] private List<PlayerLevelDataScriptable> _levelDataListPlayer;
    [SerializeField] private List<int> _winningPointPerLevel;
    [SerializeField] private int _maxLevelnumber = 2;

   private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public int GetWinningPointOfALevel(int levelNumbere)
    {
        levelNumbere = levelNumbere - 1;
        if (_winningPointPerLevel != null && levelNumbere < _winningPointPerLevel.Count)
            return _winningPointPerLevel[levelNumbere];

        else return 0;
    }
    public int getMaxLevelNumber()
    {
        return _maxLevelnumber;
    }
   
    public PlayerLevelData GetPlayerLevelData(int levelNumber)
    {
        PlayerLevelDataScriptable playerLevelDataScriptable = GetPlayerLevelScriptable(levelNumber);
        PlayerLevelData data = new PlayerLevelData();

        if (playerLevelDataScriptable != null)
        {
            data.levelNumber = playerLevelDataScriptable.levelNumber;
            data.playerGunPrefab = playerLevelDataScriptable.playerGunPrefab;
            data.playerPrefab = playerLevelDataScriptable.playerPrefab;
            return data;
        }
        return null;
    }

   

    private PlayerLevelDataScriptable GetPlayerLevelScriptable(int levelNumber)
    {
        levelNumber = levelNumber - 1;
        if (_levelDataListPlayer != null && levelNumber < _levelDataListPlayer.Count)
            return _levelDataListPlayer[levelNumber];
        else
            return null;
    }

}
