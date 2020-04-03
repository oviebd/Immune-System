using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironmentController : MonoBehaviour
{
    public static GameEnvironmentController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        OnLevelUpdate(1);
    }

   void OnLevelUpdate(int levelNumber)
    {
        levelNumber = levelNumber - 1;

        EnemySpawnController.instance.LoadLevelEnemyData(levelNumber);
        PlayerSpawnerController.instance.LoadLevelPlayerData(levelNumber);
    }

}
