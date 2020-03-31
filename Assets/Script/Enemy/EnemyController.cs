using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] List<EnemyBehaviourBase> enemyBehaviours;
	private int currentLevel = 1;
	int currentEnemyWave = 1;
	int enemyNumberInCurrentWave = 0;
	int maxEnemyNumberInCurrentWave = 0;
	float enemySpawnDelayForCurrentWave = 1.0f;

	LevelData data;

	void Start()
    {
		InvokeRepeating("SpawnEnemy", 1.0f, 1.0f);
		//SpawnEnemy();
		//SpawnEnemy();
	}
    void LoadLevelData()
    {
	    data = LevelDataHandler.instance.GetLevelData(currentLevel - 1);
		if (data == null)
			return;
        for(int i= 0; i < data.initialEnemyNumber; i++)
        {
			SpawnEnemy();
        }
    }
     
   
    // Update is called once per frame
    void SpawnEnemy()
	{
		GameObject enemyPrefab = GetSpecificEnemyPrefabBasedOnType(GetRandomEnemyType());
		if (enemyPrefab != null)
		{
			GameObject obj = InstantiatorHelper.InstantiateObject(enemyPrefab, this.gameObject);
			obj.transform.position = PositionHandler.instance.InstantiateEnemyInRandomPosition();
			UpdateEnemyNumber();
		}
		
	}

    void UpdateEnemyNumber()
    {
		enemyNumberInCurrentWave = enemyNumberInCurrentWave + 1;

        if (data != null)
        {
			if (enemyNumberInCurrentWave >= maxEnemyNumberInCurrentWave)
            {
				UpdateEnemyWaveData();
            }

		}
       
    }

	void UpdateEnemyWaveData()
	{
		currentEnemyWave = currentEnemyWave + 1;
        if(currentEnemyWave > data.numberOfWave)
        {
            //Level completed
            //Please Level Up
        }
        else
        {
			enemyNumberInCurrentWave = 0;
			maxEnemyNumberInCurrentWave = (int) (data.initialEnemyNumber * data.multiplierOfEnemyNumberPerWave);
			enemySpawnDelayForCurrentWave = data.initialEnemySpawnDelay - data.enemySpawnDelayReduceFactorPerWave * currentEnemyWave;
			if (enemySpawnDelayForCurrentWave <= 0)
				enemySpawnDelayForCurrentWave = .5f;
		}
	}

	GameObject GetSpecificEnemyPrefabBasedOnType(GameEnum.EnemyType type)
	{
		for(int i = 0; i < enemyBehaviours.Count; i++)
		{
			if( type == enemyBehaviours[i].GetEnemyType())
			{
				return enemyBehaviours[i].gameObject;
			}
		}
		return null;
	}
	
	private GameEnum.EnemyType GetRandomEnemyType()
	{
		int randomRange = Random.Range(0, 100);
		GameEnum.EnemyType type = GameEnum.EnemyType.Type_1;

		if (randomRange < 50)
			type = GameEnum.EnemyType.Type_1;
		else if (randomRange >= 50 && randomRange <= 100)
			type = GameEnum.EnemyType.Type_2;

		//type = GameEnum.EnemyType.Type_2;
		//Debug.Log("Random Range :   " + randomRange + "   Type ;  " + type);
		return type;
	}


}
