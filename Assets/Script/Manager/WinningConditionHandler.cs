using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningConditionHandler : MonoBehaviour
{
	public static WinningConditionHandler instance;


	private void Awake()
	{
		if (instance == null)
			instance = this;
	}


	public int  GetWinningPoint()
	{
		int winningPoint = 0;
		EnemyLevelData data = EnemyManager.instance.GetEnemyLevelData(1);
		if (data == null)
			return winningPoint;

		for(int i=0; i<data.numberOfWave; i++)
		{

		}

		return winningPoint;
	}

	/*public GameEnum.WinningStatus GetCurrentGameWinningStatus()
	{
		return _currentWiningStatus;
	}
	public void SetGameWiningStatus(GameEnum.WinningStatus status)
	{
		_currentWiningStatus = status;
	}
	*/
}
