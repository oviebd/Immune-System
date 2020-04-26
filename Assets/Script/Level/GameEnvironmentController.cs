using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironmentController : MonoBehaviour
{
    public static GameEnvironmentController instance;
	[SerializeField] private GameObject _parentObjForInstantiatObjs;
    private int currentLevel = 1;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void LoadLevelEnvironment(int levelNumber)
    {
		DestroyAllIntantiatedObjs();
		ShowAllInstantiatedObjs();
		EnemySpawnController.instance.LoadLevelEnemyData(levelNumber);
        PlayerSpawnerController.instance.LoadLevelPlayerData(levelNumber);
		CollectableSpawnControler.instance.LoadCollectableForALevel(levelNumber);
    }

	public void HideAllInstantiatedObjs()
	{
		_parentObjForInstantiatObjs.SetActive(false);
	}
	public void ShowAllInstantiatedObjs()
	{
		_parentObjForInstantiatObjs.SetActive(true);
	}
	public void SetEnvironmentForPlayerDieMode()
	{
		//EnemyManager.instance.MadeAllEnemyInActive();
	}
	private void DestroyAllIntantiatedObjs()
	{
		if (_parentObjForInstantiatObjs == null)
			return;
		int children = _parentObjForInstantiatObjs.transform.childCount;
		for (int i = 0; i < children; ++i)
		{
			Destroy(_parentObjForInstantiatObjs.transform.GetChild(i).gameObject);
		}
	}
}
