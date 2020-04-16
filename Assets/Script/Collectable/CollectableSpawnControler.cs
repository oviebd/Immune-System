using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnControler : MonoBehaviour
{
    public static CollectableSpawnControler instance;
    [SerializeField] private List<CollectableBase> _collectableList;
	[SerializeField] private CollectableWorldCanvasDialog _worldCanvasDialog;

	private CollectableDataModel data;
	private bool canSpawn = false;
	private float _lastSpawnTime;
	private int _spawnedCollectableNumberInCurrentLevel = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
		canSpawn = false;
	}

    public void LoadCollectableForALevel(int levelNum)
    {
        data = null;
        data = CollectableManager.instance.GetCollectableLevelData(levelNum);
        if (data == null)
            return;
		canSpawn = true;
		_lastSpawnTime = Time.time;
	}

    private void Update()
    {
		if (data == null)
			return;

		if (canSpawn)
		{
			if ((Time.time - _lastSpawnTime) >= data.minumumTimeDelayPerCollectable)
			{
				_spawnedCollectableNumberInCurrentLevel = _spawnedCollectableNumberInCurrentLevel + 1;

				if (_spawnedCollectableNumberInCurrentLevel <= data.noOfCollectableForCurrentLevel)
				{
					SpawnRandomCollectable();
					_lastSpawnTime = Time.time;
				}
				else
					canSpawn = false;
			}	
		}
	}

	public void SpawnCanvasObj(GameObject parent)
	{
		GameObject newObj = Instantiate(_worldCanvasDialog.gameObject, parent.transform);
		newObj.transform.parent = parent.transform;
	}

	#region CollectableSpawn

	void SpawnRandomCollectable()
	{
		GameObject collectablePrefab = GetSpecificCollectablePrefabBasedOnType(GetRandomCollectableType());
		SpawnCollectable(collectablePrefab);
	}
	
	void SpawnCollectable(GameObject collectablePrefab)
	{
		if (collectablePrefab != null)
		{
			GameObject obj = InstantiatorHelper.instance.InstantiateObject(collectablePrefab, this.gameObject);
			obj.transform.position = PositionHandler.instance.InstantiateCollectableInARandomPosition();
			SpawnCanvasObj(obj);
		}
	}

    GameObject GetSpecificCollectablePrefabBasedOnType(GameEnum.CollectableType type)
	{
		for (int i = 0; i < _collectableList.Count; i++)
		{
			if (type == _collectableList[i].GetCollectableType())
			{
				return _collectableList[i].gameObject;
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
