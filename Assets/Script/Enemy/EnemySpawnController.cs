using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnController : MonoBehaviour,ITimer
{
	public static EnemySpawnController instance;

	[SerializeField] List<EnemyBehaviourBase> enemyBehaviours;
	private Timer _timer;

	private bool canSpawnEnemy = false;

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

    private void Start()
    {
		GameManager.onGameStateChange += OnGameStateChanged;
		_timer = this.gameObject.GetComponent<Timer>();
    }
    private void OnDestroy()
    {
		GameManager.onGameStateChange -= OnGameStateChanged;
	}

    private void OnGameStateChanged(GameEnum.GameState gameState)
	{
		if (gameState == GameEnum.GameState.Running)
		{
			if (canSpawnEnemy)
				_timer.ResumeTimer();
		}
		else
		{
			if (canSpawnEnemy)
				_timer.PauseTimer();
		}
	}

	public void LoadLevelEnemyData(int level)
    {
		data = null;
	    data = EnemyManager.instance.GetEnemyLevelData(level);
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
		_timer.StartTimer(enemySpawnDelayForCurrentWave);
	}

	public void OnTimeCompleted()
	{
		//throw new System.NotImplementedException();
		SpawnRandomEnemy();
	}

	void UpdateEnemyNumber()
    {
		enemyNumberInCurrentWave = enemyNumberInCurrentWave + 1;

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
		int prevVal = 0;
		foreach (KeyValuePair<GameEnum.EnemyType, int> keyValue in data.enemyTypeAndPercentageDictionary)
		{
			if (randomRange >= prevVal && randomRange <= keyValue.Value)
				return keyValue.Key;
			prevVal = keyValue.Value;
		}
		return GameEnum.EnemyType.Type_1;
	}

   
    #endregion EnemySpawn



}
