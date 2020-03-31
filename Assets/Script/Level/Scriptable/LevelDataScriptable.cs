using UnityEngine;

[CreateAssetMenu]
public class LevelDataScriptable : ScriptableObject
{
	public int levelNumber = 1;
	public int numberOfWave = 4;
    public int initialEnemyNumber = 4;
	public float initialEnemySpawnDelay = 2;
	public float enemySpawnDelayReduceFactorPerWave = .5f;
	public int initialNumberOfEnemyInAWave = 30;
	public float multiplierOfEnemyNumberPerWave = 1.5f; // number of enemy increase per wave
}
