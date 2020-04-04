using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironmentController : MonoBehaviour
{
    public static GameEnvironmentController instance;

    private int currentLevel = 1;
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        ScoreManager.onPlayerWin += OnlevelCompleted;
    }
    void Start()
    {
        OnLevelUpdate(currentLevel);
    }

   void OnLevelUpdate(int levelNumber)
    {
        levelNumber = levelNumber - 1;

        EnemySpawnController.instance.LoadLevelEnemyData(levelNumber);
        PlayerSpawnerController.instance.LoadLevelPlayerData(levelNumber);
    }

    void OnlevelCompleted()
    {
        currentLevel = currentLevel + 1;
        Debug.Log("Level Completed....updated Level  " + currentLevel);
    }

}
