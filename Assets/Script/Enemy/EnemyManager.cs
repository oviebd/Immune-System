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

	private IENemyBehaviour[] GetAllenemy()
	{
		IENemyBehaviour[] enemyList;
		//enemyList = FindObjectsOfType<MonoBehaviour>().OfType<IENemyBehaviour>();
		return enemyList;
	}

	public void MadeAllEnemyInActive()
	{
		//EnemyBehaviourBase[] enemyList = GetAllenemy();
		if(enemyList != null)
		{
			for(int i = 0; i < enemyList.Length; i++)
			{
				enemyList[i].SetInactiveMode();
			}
		}
	}


}
