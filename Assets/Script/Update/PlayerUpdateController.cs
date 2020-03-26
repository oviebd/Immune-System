using UnityEngine;
using System.Collections;

public class PlayerUpdateController : MonoBehaviour
{
    private enum UpgrateStatus { upgrade,degrade}

    [SerializeField] private float _timeForNextUpdate = 5.0f; 
    [SerializeField] private int _enemyNumber = 5; // number of enemy need to destroy in a given time 

    private float _lastUpdateTime;
    private float _enemyCountInCurrentUpdateSession;

    public delegate void PlayerSystemUpdate(GameEnum.UpgradeType upgradeType);
    public static event PlayerSystemUpdate onPlayerSystemUpdate;

    private void Awake()
    {
        EnemyBehaviourBase.enemyDestroyedByPlayer += onEnemyDestroyed;
    }

    private void Start()
    {
        ResetUpdate();
    }

    private void Update()
    {
        if (IsTimePassed() == true)
        {
            UpdatePlayerUpgradeStatus(UpgrateStatus.degrade);
        }
    }

    void onEnemyDestroyed(EnemyBehaviourBase enemyBehaviour)
    {
        _enemyCountInCurrentUpdateSession = _enemyCountInCurrentUpdateSession + 1;

        // Upgrade Time has passed and player can not destroy expected number of enemy. So Degrade his status
        if(IsTimePassed() == true) 
        {
            UpdatePlayerUpgradeStatus(UpgrateStatus.degrade);
            return;
        }

        if(_enemyCountInCurrentUpdateSession >= _enemyNumber )
        {
            UpdatePlayerUpgradeStatus(UpgrateStatus.upgrade);
        }
    }

    void UpdatePlayerUpgradeStatus(UpgrateStatus status)
    {
        ResetUpdate();

        if(status == UpgrateStatus.upgrade)
            onPlayerSystemUpdate(GameEnum.UpgradeType.AddGun);
        else if (status == UpgrateStatus.degrade)
            onPlayerSystemUpdate(GameEnum.UpgradeType.RemoveGun);
    }

    private void ResetUpdate()
    {
        _lastUpdateTime = Time.time;
        _enemyCountInCurrentUpdateSession = 0;
    }

    private bool IsTimePassed()
    {
        float timeElapsed = Time.time - _lastUpdateTime;

        if (timeElapsed <= _timeForNextUpdate)
            return false;
        else
            return true;
    }

    private void OnDestroy()
    {
        EnemyBehaviourBase.enemyDestroyedByPlayer -= onEnemyDestroyed;
    }

}
