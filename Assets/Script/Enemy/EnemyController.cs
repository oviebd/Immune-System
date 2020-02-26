using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public GameObject enemyPrefab;
	void Start()
    {
		InvokeRepeating("SpawnEnemy", 1.0f, 5.0f);
    }

    // Update is called once per frame
    void SpawnEnemy()
	{
		GameObject obj = InstantiatorHelper.InstantiateObject(enemyPrefab, this.gameObject);
		obj.transform.position = PositionHandler.instance.getRandomPosition();
	}
}
