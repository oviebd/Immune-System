using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyLevelDataScriptable : ScriptableObject
{
	public int levelNumber = 1;
	public int numberOfWave = 4;
	public float initialEnemySpawnDelay = 2;
	public float enemySpawnDelayReduceFactorPerWave = .5f;
	public int initialNumberOfEnemyInAWave = 30;
	public float multiplierOfEnemyNumberPerWave = 1.5f; // number of enemy increase per wave
	public List<GameEnum.EnemyType> enemyTypes;
	public List<int> enemyPercentageList;
}

