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
        PlayerSpawnerController.instance.LoadPlayer();
		CollectableSpawnControler.instance.LoadCollectableForALevel(levelNumber);
		BackGroundController.instance.SetBackground(levelNumber);
    }

	public void HideAllInstantiatedObjs()
	{
		_parentObjForInstantiatObjs.SetActive(false);
		PlayerSpawnerController.instance.HidePlayer();
	}
	public void ShowAllInstantiatedObjs()
	{
		_parentObjForInstantiatObjs.SetActive(true);
		PlayerSpawnerController.instance.ShowPlayer();
	}
	public void SetEnvironmentForPlayerDieMode()
	{
		//EnemyManager.instance.MadeAllEnemyInActive();
	}
    public void SetEnvironmentForTutorial()
    {
		HideAllInstantiatedObjs();
		PlayerSpawnerController.instance.ShowPlayer();
	}
	public void SetEnvironmentForTutorialComplete()
	{
		ShowAllInstantiatedObjs();
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
		if (PlayerSpawnerController.instance.GetCurrentPlayerController() != null)
			Destroy(PlayerSpawnerController.instance.GetCurrentPlayerController().gameObject);
	}

}
