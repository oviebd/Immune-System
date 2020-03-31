using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{
    public static LevelDataHandler instance;
   // [SerializeField] private int _currentLevel = 1;
    [SerializeField] private List<LevelDataScriptable> _levelList ;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public LevelData GetLevelData(int levelNumber)
    {
        LevelDataScriptable levelDataScriptable = GetLevelScriptable(levelNumber);
        LevelData data = new LevelData();

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

    private LevelDataScriptable GetLevelScriptable(int levelNumber)
    {
        //return _levelList[0];
        if (_levelList != null && levelNumber < _levelList.Count)
            return _levelList[levelNumber];
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
