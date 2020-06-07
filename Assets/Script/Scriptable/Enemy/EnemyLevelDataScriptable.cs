using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyLevelDataScriptable : ScriptableObject
{
	[Header("Level number for this setting")]
	public int levelNumber = 1;
	[Header("Enemy Wave Number")]
	public int numberOfWave = 4;
	[Header("first wave enemy delay in second. Delay for spawning each enemy")]
	public float initialEnemySpawnDelay = 2;
	[Header("how much delay  (second) reduced per wave (starts from second wave)")]
	public float enemySpawnDelayReduceFactorPerWave = .5f;
	[Header("First Wave Ememy Number")]
	public int initialNumberOfEnemyInAWave = 30;
	[Header("How many enemy number increased per wave")]
	public float multiplierOfEnemyNumberPerWave = 1.5f; // number of enemy increase per wave

	[Header("Enemy List for this Level. Do not dublicate enemy")]
	public List<GameEnum.EnemyType> enemyTypes;
	[Header("Percentahe of each enemy. maintain enemyType list order. made perentage sum exactly 100")]
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