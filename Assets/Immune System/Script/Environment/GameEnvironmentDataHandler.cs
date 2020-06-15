using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironmentDataHandler : MonoBehaviour
{
	public static GameEnvironmentDataHandler instance;
	[Header("Environment Level Data Scriptable List")]
	[SerializeField] private List<EnvironmentLevelDataScriptable> _environmentScriptableDataList;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public GameEnvironmentDataModel GetEnvironmentData(int levelNumber)
	{
		EnvironmentLevelDataScriptable environmentDataScriptable = GetEnvironmentLevelScriptable(levelNumber);
		GameEnvironmentDataModel data = new GameEnvironmentDataModel();

		if (environmentDataScriptable != null)
		{
			data.levelNumber = environmentDataScriptable.levelNumber;
			data.backgroundImage = environmentDataScriptable.backgroundImage;
			data.audioClip = environmentDataScriptable.audioClip;

			UpdateData updateData = new UpdateData();
			updateData.requiredEnemy = environmentDataScriptable.requiredEnemy;
			updateData.requiredTime = environmentDataScriptable.requiredTime;
			updateData.updateFactor = environmentDataScriptable.updateFactor;
			data.updateData = updateData;
			return data;
		}
		return null;
	}

	private EnvironmentLevelDataScriptable GetEnvironmentLevelScriptable(int levelNumber)
	{
		levelNumber = levelNumber - 1;
		if (_environmentScriptableDataList != null && levelNumber < _environmentScriptableDataList.Count)
			return _environmentScriptableDataList[levelNumber];
		else
			return null;
	}
}
