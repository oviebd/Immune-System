using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager instance; 
    [SerializeField] private List<CollectableLevelDataScriptable> _collectableLevelDataList;

	private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public CollectableDataModel GetCollectableLevelData(int levelNumber)
	{
		CollectableLevelDataScriptable levelDataScriptable = GetCollectableLevelScriptable(levelNumber);
		CollectableDataModel data = new CollectableDataModel();

		if (levelDataScriptable != null)
		{
			data.levelNumber = levelDataScriptable.levelNumber;
			data.noOfCollectableForCurrentLevel = levelDataScriptable.noOfCollectableForCurrentLevel;
			data.minumumTimeDelayPerCollectable = levelDataScriptable.minumumTimeDelayPerCollectable;
			data.collectableTypeAndPercentageDictionary = GenerateCollectableDictionary(levelDataScriptable);
			return data;
		}
		return null;
	}
	Dictionary<GameEnum.CollectableType, int> GenerateCollectableDictionary(CollectableLevelDataScriptable levelDataScriptable)
	{
		Dictionary<GameEnum.CollectableType, int> collectableTypeAndPercentageDictionary = new Dictionary<GameEnum.CollectableType, int>();
		int sumPercentage = 0;
		for (int i = 0; i < levelDataScriptable.collectableType.Count && i < levelDataScriptable.collectablePercentageList.Count; i++)
		{
			sumPercentage = sumPercentage + levelDataScriptable.collectablePercentageList[i];
			collectableTypeAndPercentageDictionary.Add(levelDataScriptable.collectableType[i], sumPercentage);
		}
		return collectableTypeAndPercentageDictionary;
	}

	private CollectableLevelDataScriptable GetCollectableLevelScriptable(int levelNumber)
	{
		levelNumber = levelNumber - 1;
		if (_collectableLevelDataList != null && levelNumber < _collectableLevelDataList.Count)
			return _collectableLevelDataList[levelNumber];
		else
			return null;
	}

	


}
