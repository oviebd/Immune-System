using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{
    public static LevelDataHandler instance;
   // [SerializeField] private int _currentLevel = 1;
    [SerializeField] private List<EnemyLevelDataScriptable> _levelDataListEnemy ;
    [SerializeField] private List<PlayerLevelDataScriptable> _levelDataListPlayer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public EnemyLevelData GetEnemyLevelData(int levelNumber)
    {
        EnemyLevelDataScriptable levelDataScriptable = GetLevelScriptable(levelNumber);
        EnemyLevelData data = new EnemyLevelData();

        if (levelDataScriptable != null)
        {
            data.levelNumber = levelDataScriptable.levelNumber;
            data.numberOfWave = levelDataScriptable.numberOfWave;
            data.initialEnemyNumber = levelDataScriptable.initialEnemyNumber;
            data.initialEnemySpawnDelay = levelDataScriptable.initialEnemySpawnDelay;
            data.enemySpawnDelayReduceFactorPerWave = levelDataScriptable.enemySpawnDelayReduceFactorPerWave;
            data.initialNumberOfEnemyInAWave = levelDataScriptable.initialNumberOfEnemyInAWave;
            data.multiplierOfEnemyNumberPerWave = levelDataScriptable.multiplierOfEnemyNumberPerWave;

            return data;
        }

        return null;
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

    private EnemyLevelDataScriptable GetLevelScriptable(int levelNumber)
    {
        if (_levelDataListEnemy != null && levelNumber < _levelDataListEnemy.Count)
            return _levelDataListEnemy[levelNumber];
        else
            return null;
    }

    private PlayerLevelDataScriptable GetPlayerLevelScriptable(int levelNumber)
    {
        if (_levelDataListPlayer != null && levelNumber < _levelDataListPlayer.Count)
            return _levelDataListPlayer[levelNumber];
        else
            return null;
    }

    /* public int GetCurrentLevelNumber()
     {
         return _currentLevel;
     }
     public void SetCurrentLevelNumber(int levelNumber)
     {
         _currentLevel = levelNumber;
     }*/


}
