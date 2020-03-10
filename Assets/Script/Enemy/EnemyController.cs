using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] List<EnemyBehaviourBase> enemyBehaviours;
	void Start()
    {
		InvokeRepeating("SpawnEnemy", 1.0f, 2.0f);
		//SpawnEnemy();
	}

    // Update is called once per frame
    void SpawnEnemy()
	{
		GameObject enemyPrefab = GetSpecificEnemyPrefabBasedOnType(GetRandomEnemyType());
		if (enemyPrefab != null)
		{
			GameObject obj = InstantiatorHelper.InstantiateObject(enemyPrefab, this.gameObject);
			obj.transform.position = PositionHandler.instance.getRandomPosition();
		}
		
	}

	GameObject GetSpecificEnemyPrefabBasedOnType(GameEnum.EnemyType type)
	{
		for(int i = 0; i < enemyBehaviours.Count; i++)
		{
			if( type == enemyBehaviours[i].GetEnemyType())
			{
				return enemyBehaviours[i].gameObject;
			}
		}
		return null;
	}
	
	private GameEnum.EnemyType GetRandomEnemyType()
	{
		int randomRange = Random.Range(0, 100);
		GameEnum.EnemyType type = GameEnum.EnemyType.Type_1;

		if (randomRange < 50)
			type = GameEnum.EnemyType.Type_1;
		else if (randomRange >= 50 && randomRange <= 100)
			type = GameEnum.EnemyType.Type_2;

		type = GameEnum.EnemyType.Type_1;
		//Debug.Log("Random Range :   " + randomRange + "   Type ;  " + type);
		return type;
	}


}
