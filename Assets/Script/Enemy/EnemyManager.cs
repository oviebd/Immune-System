using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public static EnemyManager instance;
	[SerializeField] private List<EnemyLevelDataScriptable> _levelDataListEnemy;

	[SerializeField] List<EnemyBehaviourBase> enemyBehaviours;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}
	public EnemyLevelData GetEnemyLevelData(int levelNumber)
	{
		EnemyLevelDataScriptable levelDataScriptable = GetEnemyLevelScriptable(levelNumber);
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
			data.enemyTypeAndPercentageDictionary = GenerateDictionary(levelDataScriptable);
			return data;
		}
		return null;
	}
	Dictionary<GameEnum.EnemyType, int> GenerateDictionary(EnemyLevelDataScriptable levelDataScriptable)
	{
		Dictionary<GameEnum.EnemyType, int> enemyTypeAndPercentageDictionary = new Dictionary<GameEnum.EnemyType, int>();
		int sumPercentage = 0;
		for (int i = 0; i < levelDataScriptable.enemyTypes.Count && i < levelDataScriptable.enemyPercentageList.Count; i++)
		{
			sumPercentage = sumPercentage + levelDataScriptable.enemyPercentageList[i];
			enemyTypeAndPercentageDictionary.Add(levelDataScriptable.enemyTypes[i],sumPercentage);
		}
		return enemyTypeAndPercentageDictionary;
	}
	private EnemyLevelDataScriptable GetEnemyLevelScriptable(int levelNumber)
	{
		levelNumber = levelNumber - 1;
		if (_levelDataListEnemy != null && levelNumber < _levelDataListEnemy.Count)
			return _levelDataListEnemy[levelNumber];
		else
			return null;
	}

	/*private List<IENemyBehaviour> GetAllenemy()
	{
		List<IENemyBehaviour> enemyList = new List<IENemyBehaviour>();
		//IENemyBehaviour[] enemyList;
		enemyList = FindObjectsOfType<MonoBehaviour>().OfType<IENemyBehaviour>() as List<IENemyBehaviour>;
		return enemyList;
	}

	public void MadeAllEnemyInActive()
	{
		List<IENemyBehaviour> enemyList = GetAllenemy();
		Debug.Log("enem list count " + enemyList.Count);
		if(enemyList != null)
		{
			for(int i = 0; i < enemyList.Count; i++)
			{
				enemyList[i].OnMovementStop();
			}
		}
	}*/


}
