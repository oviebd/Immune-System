using UnityEngine;
using System.Collections;

public class PlayerUpdateController : MonoBehaviour
{
    private enum UpgrateStatus { upgrade,degrade}

    [SerializeField] private float _timeForNextUpdate = 5.0f; 
    [SerializeField] private int _enemyNumber = 5; // number of enemy need to destroy in a given time 
    [SerializeField] private float updateFactor = 5;

    private float _lastUpdateTime;
    private float _enemyCountInCurrentUpdateSession;

    public delegate void PlayerSystemUpdate(GameEnum.UpgradeType upgradeType);
    public static event PlayerSystemUpdate onPlayerSystemUpdate;

    private int currentUpdateNumber = 0;

    #region CallBacks Initializations
    private void Awake()
    {
        EnemyBehaviourBase.enemyDestroyedByPlayer += onEnemyDestroyed;
        GameManager.onGameStateChange += OnGameStateChange;
    }
    private void OnDestroy()
    {
        EnemyBehaviourBase.enemyDestroyedByPlayer -= onEnemyDestroyed;
        GameManager.onGameStateChange -= OnGameStateChange;
    }
    #endregion CallBacks Initializations


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
            UpdatePlayerUpgradeStatus(UpgrateStatus.upgrade);
        
    }

    void UpdatePlayerUpgradeStatus(UpgrateStatus status)
    {
		if (onPlayerSystemUpdate == null)
			return;

		ResetUpdate();

        if(status == UpgrateStatus.upgrade)
        {
            currentUpdateNumber = currentUpdateNumber + 1;
            onPlayerSystemUpdate(GameEnum.UpgradeType.AddGun);
            UpdateUpdateData();
        }
            
        else if (status == UpgrateStatus.degrade)
        {
            currentUpdateNumber = currentUpdateNumber - 1;
            if (currentUpdateNumber <= 0)
                currentUpdateNumber = 0;

            onPlayerSystemUpdate(GameEnum.UpgradeType.RemoveGun);
            UpdateUpdateData();
        }  
    }

    private bool IsTimePassed()
    {
        float timeElapsed = Time.time - _lastUpdateTime;

        if (timeElapsed <= _timeForNextUpdate)
            return false;
        else
            return true;
    }


    private void ResetUpdate()
    {
        _lastUpdateTime = Time.time;
        _enemyCountInCurrentUpdateSession = 0;
    }

    private void UpdateUpdateData()
    {
        _enemyNumber = _enemyNumber + (int)(currentUpdateNumber * updateFactor);
        //Debug.Log("Current update Num = " + currentUpdateNumber + " enemy :  " + _enemyNumber);
    }

    private void OnGameStateChange(GameEnum.GameState gameState)
    {
        if (gameState == GameEnum.GameState.Idle || gameState == GameEnum.GameState.PlayerWin || gameState == GameEnum.GameState.PlayerLose)
        {
            ResetUpdate();
            currentUpdateNumber = 0;
            UpdateUpdateData();
        }
    }

}
