using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnControler : MonoBehaviour
{
    public static CollectableSpawnControler instance;
    [SerializeField] private List<CollectableBase> _collectableList;
	[SerializeField] private CollectableWorldCanvasDialog _worldCanvasDialog;
	private GameObject _collectableTopicDialogObject;

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
		_spawnedCollectableNumberInCurrentLevel = 0;
		data = CollectableManager.instance.GetCollectableLevelData(levelNum);
        if (data == null)
            return;
		
		canSpawn = true;
		_lastSpawnTime = Time.time;
	}

    private void Update()
    {
		if (data == null || Utils.CanSpawnThings () == false)
        {
			_lastSpawnTime = Time.time;
			return;
		}
			

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
