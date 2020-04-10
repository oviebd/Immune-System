using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnController : MonoBehaviour
{
	public static EnemySpawnController instance;

	[SerializeField] List<EnemyBehaviourBase> enemyBehaviours;

	private bool canSpawnEnemy = false;
	private float lastSpawnEnemyTime;

	private int currentEnemyWave = 1;
	private int enemyNumberInCurrentWave = 0;
	private int maxEnemyNumberInCurrentWave = 0;
	private float enemySpawnDelayForCurrentWave = 1.0f;

	private EnemyLevelData data;

	public Text debugText;

    private void Awake()
    {
		if (instance == null)
			instance = this;
	}


    private void Update()
    {
        if (canSpawnEnemy)
        {
            if( (Time.time - lastSpawnEnemyTime) >= enemySpawnDelayForCurrentWave)
            {
				SpawnRandomEnemy();
            }
			string res = " L : " +LevelManager.instance.GetCurrentLevelNumber() + " wave : " + ( currentEnemyWave )+ " enemy Number : " + enemyNumberInCurrentWave + " / " + maxEnemyNumberInCurrentWave;
			debugText.text = res;
		}
	}
	public void LoadLevelEnemyData(int level)
    {
		data = null;
	    data = LevelDataHandler.instance.GetEnemyLevelData(level);
        if (data == null)
			return;
		ResetCurrentLevelEnemyData();
	    for(int i= 0; i < data.initialEnemyNumber; i++)
		 {
			SpawnSpecificTypeEnemy(GameEnum.EnemyType.Type_2);
		}
	}

    void ResetCurrentLevelEnemyData()
    {
		enemyNumberInCurrentWave = 0;
		if (currentEnemyWave == 1)
        {
			maxEnemyNumberInCurrentWave = data.initialNumberOfEnemyInAWave;
			enemySpawnDelayForCurrentWave = data.initialEnemySpawnDelay;
		}
        else
        {
			maxEnemyNumberInCurrentWave += (int)(data.initialNumberOfEnemyInAWave * data.multiplierOfEnemyNumberPerWave);
			enemySpawnDelayForCurrentWave = data.initialEnemySpawnDelay - (data.enemySpawnDelayReduceFactorPerWave * (currentEnemyWave - 1));
		}

		if (enemySpawnDelayForCurrentWave <= 0)
			enemySpawnDelayForCurrentWave = .5f;

		canSpawnEnemy = true;
	}

    void UpdateEnemyNumber()
    {
		enemyNumberInCurrentWave = enemyNumberInCurrentWave + 1;
		lastSpawnEnemyTime = Time.time;

		if (enemyNumberInCurrentWave > maxEnemyNumberInCurrentWave)
		{
			UpdateEnemyWaveData();
		}
	}

	void UpdateEnemyWaveData()
	{
		currentEnemyWave = currentEnemyWave + 1;
		if (currentEnemyWave <= data.numberOfWave) 
        {
            //Spawn Next wave enemy
			ResetCurrentLevelEnemyData();
		}
        else
        {
			//Enemy creation in this Level completed
			canSpawnEnemy = false;
		}
		
	}



	#region EnemySpawn
	void SpawnRandomEnemy()
	{
		GameObject enemyPrefab = GetSpecificEnemyPrefabBasedOnType(GetRandomEnemyType());
		SpawnEnemy(enemyPrefab);
	}
	void SpawnSpecificTypeEnemy(GameEnum.EnemyType type)
	{
		GameObject enemyPrefab = GetSpecificEnemyPrefabBasedOnType(type);
		SpawnEnemy(enemyPrefab);
	}
	void SpawnEnemy(GameObject enemyPrefab)
	{
		if (enemyPrefab != null)
		{
			GameObject obj = InstantiatorHelper.instance.InstantiateObject(enemyPrefab, this.gameObject);
			obj.transform.position = PositionHandler.instance.InstantiateEnemyInRandomPosition();
			UpdateEnemyNumber();
		}
	}
	GameObject GetSpecificEnemyPrefabBasedOnType(GameEnum.EnemyType type)
	{
		for (int i = 0; i < enemyBehaviours.Count; i++)
		{
			if (type == enemyBehaviours[i].GetEnemyType())
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
	#endregion EnemySpawn



}
