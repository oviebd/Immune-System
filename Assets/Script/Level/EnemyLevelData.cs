using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelData 
{
	public int levelNumber = 1;
	public int numberOfWave = 4;
	public int initialEnemyNumber = 4;
	public float initialEnemySpawnDelay = 2;
	public float enemySpawnDelayReduceFactorPerWave = .5f;
	public int initialNumberOfEnemyInAWave = 30;
	public float multiplierOfEnemyNumberPerWave = 1.5f;

	public List<GameEnum.EnemyType> _enemyTypes;
}
