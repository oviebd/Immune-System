using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnControler : MonoBehaviour,ITimer
{
    public static CollectableSpawnControler instance;
	[Header("Collectable Prefab (CollectableBase) List")]
	[SerializeField] private List<CollectableBase> _collectableList;
	[SerializeField] private CollectableWorldCanvasDialog _worldCanvasDialog;
	private GameObject _collectableTopicDialogObject;

	private CollectableDataModel data;
	private bool canSpawn = false;
	private Timer _timer;
	private int _spawnedCollectableNumberInCurrentLevel = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
		GameManager.onGameStateChange += OnGameStateChanged;
		_timer = this.gameObject.GetComponent<Timer>();
		canSpawn = false;
	}
	private void OnDestroy()
	{
		GameManager.onGameStateChange -= OnGameStateChanged;
	}

	private void OnGameStateChanged(GameEnum.GameState gameState)
	{
		if (gameState == GameEnum.GameState.Running)
		{
			if (canSpawn)
				_timer.ResumeTimer();
		}
		else
		{
			if (canSpawn)
				_timer.PauseTimer();
		}
	}


	public void LoadCollectableForALevel(int levelNum)
    {
        data = null;
		_spawnedCollectableNumberInCurrentLevel = 0;
		data = CollectableManager.instance.GetCollectableLevelData(levelNum);
        if (data == null)
            return;
		
		canSpawn = true;
		_timer.StartTimer(GetNextSpawnTime());
	}


	public void OnTimeCompleted()
	{
		_spawnedCollectableNumberInCurrentLevel = _spawnedCollectableNumberInCurrentLevel + 1;
		if (_spawnedCollectableNumberInCurrentLevel <= data.noOfCollectableForCurrentLevel)
		{
			SpawnRandomCollectable();
		}
		else
			canSpawn = false;
		_timer.StartTimer(GetNextSpawnTime());
	}

    private float GetNextSpawnTime()
    {
		float nextTime = 2000.0f;
		if (data != null)
			nextTime = Random.RandomRange(data.minumumTimeDelayPerCollectable, (data.minumumTimeDelayPerCollectable * 2));
		return nextTime;
    }

	#region CollectableSpawn

	private void SpawnRandomCollectable()
	{
		CollectableBase collectableBasePrefab = GetSpecificCollectablePrefabBasedOnType(GetRandomCollectableType());
		SpawnCollectable(collectableBasePrefab);
	}
	
	private void SpawnCollectable(CollectableBase collectableBasePrefab)
	{
		if (collectableBasePrefab != null)
		{
			GameObject obj = InstantiatorHelper.instance.InstantiateObject(collectableBasePrefab.gameObject, this.gameObject);
			obj.transform.position = PositionHandler.instance.InstantiateCollectableInARandomPosition();

			if (PlayerAchivedDataHandler.instance.IsThisCollectableAlreadyConsumedByPlayer(collectableBasePrefab.GetCollectableType()) == false)
				SpawnCollectableTopicDialog(obj, collectableBasePrefab.GetCollectableType());
		}
	}

	public void SpawnCollectableTopicDialog(GameObject parent, GameEnum.CollectableType type)
	{
		_collectableTopicDialogObject = Instantiate(_worldCanvasDialog.gameObject, parent.transform);
		_collectableTopicDialogObject.transform.parent = parent.transform;
        _collectableTopicDialogObject.GetComponent<CollectableWorldCanvasDialog>().SetCollectableMessageBasedOnCollectableType(type);
	}
	private CollectableBase GetSpecificCollectablePrefabBasedOnType(GameEnum.CollectableType type)
	{
		for (int i = 0; i < _collectableList.Count; i++)
		{
			if (type == _collectableList[i].GetCollectableType())
			{
				return _collectableList[i];
			}
		}
		return null;
	}

	private GameEnum.CollectableType GetRandomCollectableType()
	{
		int randomRange = Random.Range(0, 100);
		int prevVal = 0;
		foreach (KeyValuePair<GameEnum.CollectableType, int> keyValue in data.collectableTypeAndPercentageDictionary)
		{
			if (randomRange >= prevVal && randomRange <= keyValue.Value)
				return keyValue.Key;
			prevVal = keyValue.Value;
		}
		return GameEnum.CollectableType.Life;
	}
	#endregion CollectableSpawn
}
