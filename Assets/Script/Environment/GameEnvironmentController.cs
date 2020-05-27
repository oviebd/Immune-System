using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironmentController : MonoBehaviour
{
    public static GameEnvironmentController instance;
	[SerializeField] private GameObject _parentObjForInstantiatObjs;

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
        PlayerSpawnerController.instance.LoadPlayerForGame();
		CollectableSpawnControler.instance.LoadCollectableForALevel(levelNumber);
		EnvironmentGraphicsSetter.instance.SetBackground(levelNumber);
    }


    public void PrepareGameOverEnvironment(bool isWin)
    {
		if (isWin == false)
			EnemySpawnController.instance.SetEnemyModeActiveInactive(false);
        else
        {
			PlayerSpawnerController.instance.GetCurrentGamePlayerController().GetIgunController().StopShooting();
			EnvironmentGraphicsSetter.instance.RunPlayerWinExplosion();
			GameUiVisibilityHandler.instance.ShowAnimatedMessage("Congratulations!");
			EnemyBehaviourBase[] enemy = FindObjectsOfType<EnemyBehaviourBase>();
			if (enemy != null && enemy.Length > 0)
			{
				for (int i = 0; i < enemy.Length; i++)
				{
					enemy[i].gameObject.GetComponent<IReward>().SetReward(0);
					enemy[i].DestroyObj();
				}
			}
		}
	}

	public void HideAllInstantiatedObjs()
	{
		HideAllObjsExceptPlayer();
		PlayerSpawnerController.instance.HidePlayer();
	}
    private void HideAllObjsExceptPlayer()
    {
		_parentObjForInstantiatObjs.SetActive(false);
	}

	public void ShowAllInstantiatedObjs()
	{
		_parentObjForInstantiatObjs.SetActive(true);
		PlayerSpawnerController.instance.ShowPlayer();
	}
	

    public void SetEnvironmentForTutorial()
    {
		HideAllInstantiatedObjs();
		PlayerSpawnerController.instance.LoadPlayerForTutorial();
	}

    public void SetEnvironmentForTutorialComplete()
	{
       if( PlayerSpawnerController.instance.GetCurrentTutorialPlayerController() != null)
        {
			Destroy(PlayerSpawnerController.instance.GetCurrentTutorialPlayerController().gameObject);
        }
       if(GameManager.instance.GetCurrentGameState() == GameEnum.GameState.Running)
        {
			ShowAllInstantiatedObjs();
		}
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
		if (PlayerSpawnerController.instance.GetCurrentGamePlayerController() != null)
			Destroy(PlayerSpawnerController.instance.GetCurrentGamePlayerController().gameObject);
	}

}
