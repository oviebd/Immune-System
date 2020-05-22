using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunType_2_SpawnEnemy : GunBase, IGun
{
    [SerializeField] private bool _canShoot = false;

    public void SetShootingCapabilities(bool canShoot)
    {
        this._canShoot = canShoot;
    }

    public void Shoot()
    {
        if (_canShoot)
        {
            GameObject enemyObject = InstantiateBullet();
            if (enemyObject == null)
                return;
            SetSpawnedEnemyProperties(enemyObject);
        }
    }

    void SetSpawnedEnemyProperties(GameObject enemyObject)
    {
        IReward reward = enemyObject.GetComponent<IReward>();
        if (reward != null)
            reward.SetReward(0);
        EnemyBehaviourBase enemyBehaviour = enemyObject.GetComponent<EnemyBehaviourBase>();
        enemyBehaviour.SetIsEnemyEnteredGameSceneValue(true);
        enemyBehaviour.SetActiveMode();
    }
}
