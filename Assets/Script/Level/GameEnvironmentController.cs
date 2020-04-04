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
    }
    public void LoadLebvelEnvironment(int levelNumber)
    {
        EnemySpawnController.instance.LoadLevelEnemyData(levelNumber);
        PlayerSpawnerController.instance.LoadLevelPlayerData(levelNumber);
    }



}
