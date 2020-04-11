using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public static EnemyManager instance;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	/*private List<IENemyBehaviour> GetAllenemy()
	{
		List<IENemyBehaviour> enemyList = new List<IENemyBehaviour>();
		//IENemyBehaviour[] enemyList;
		enemyList = FindObjectsOfType<MonoBehaviour>().OfType<IENemyBehaviour>() as List<IENemyBehaviour>;
		return enemyList;
	}

	public void MadeAllEnemyInActive()
	{
		List<IENemyBehaviour> enemyList = GetAllenemy();
		Debug.Log("enem list count " + enemyList.Count);
		if(enemyList != null)
		{
			for(int i = 0; i < enemyList.Count; i++)
			{
				enemyList[i].OnMovementStop();
			}
		}
	}*/


}
