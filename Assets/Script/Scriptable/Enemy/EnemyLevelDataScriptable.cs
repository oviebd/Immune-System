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

// initialEnemySpawnDelay - first wave enemy delay . Delay for spawning each enemy
//enemySpawnDelayReduceFactorPerWave - how much delay time reduced per wave .
//Ex - initialEnemySpawnDelay is 2 and enemySpawnDelayReduceFactorPerWave is 0.5 and wave number is 3
//So 1st wave enemy delay - 2 , 2nd wave enemy delay is  2 - .5 = 1.5 , 3rd wave enemy delay is 1.5 -.5 = 1


// initialNumberOfEnemyInAWave - means how many enemy in first wave.
// multiplierOfEnemyNumberPerWave - means how many enemy number increased per wave
// example - initialNumberOfEnemyInAWave is 30 and multiplierOfEnemyNumberPerWave is 1.5 and wave Number is 4
// so i 1 wave enemy number = 30 , 2nd wave enemy number will be 30 + (30 * 1.5) = 45 and
// 3rd vwave enemy number will be , 45 + (45 * 1.5 ) = 112