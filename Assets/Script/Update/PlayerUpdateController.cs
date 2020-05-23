using UnityEngine;
using System.Collections;

/*At First UpdateWave ( waveNumber = 1) there is no time Limit for destroying a number of enemy
 *After completing first wave (waveNumber = 2) . Player needs to destroy a number of enemies within a time
 *    If he succided then player updated and increase waveNumber otherwise player deGrade and decrease waveNumber
 *If Player obtains the maximum update waveNumber then player can not be updated anymore but player need to continue his
 * existing performance for keeping his update status otherwise he lose his update and get degraded. 
 */
public class PlayerUpdateController : MonoBehaviour,ITimer
{
    public static PlayerUpdateController instance;

    private enum UpgrateStatus { upgrade,degrade}

    private float _requiredTime = 5.0f; 
    private int _requiredEnemy = 5; //Base number of enemy need to destroy in a given time.
    private float _updateFactor = 5;  // Used for set Difficulty .Responsible for calculated enemy number based on waveNumber

    private float _requiredTimeForCurrentWave = 5.0f;
    private int   _requiredEnemyForCurrentWave = 0;
    private int   _currentWaveNumber = 1;
    private PlayerUpdateModel _updateDataModel;
    private int _maxWaveNum = 3;

    private Timer _timer;

    public delegate void PlayerSystemUpdate(GameEnum.UpgradeType upgradeType);
    public static event PlayerSystemUpdate onPlayerSystemUpdate;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        EnemyBehaviourBase.enemyDestroyedByPlayer += onEnemyDestroyed;
        GameManager.onGameStateChange += OnGameStateChange;
    }
    private void OnDestroy()
    {
        EnemyBehaviourBase.enemyDestroyedByPlayer -= onEnemyDestroyed;
        GameManager.onGameStateChange -= OnGameStateChange;
    }

    private void Start()
    {
        _timer = GetComponent<Timer>();
		_updateDataModel = new PlayerUpdateModel();
        _timer.StartTimer(_requiredTimeForCurrentWave);
        ResetUpdate();
    }

    public void SetUpdateData( UpdateData data)
    {
        this._requiredTime = data.requiredTime;
        this._requiredEnemy = data.requiredEnemy;
        this._updateFactor = data.updateFactor;

        _currentWaveNumber = 1;
        _requiredTimeForCurrentWave = _requiredTime;
        ResetUpdate();
    }

    private void Update()
    {
		ResetUpdateDataModel();
        if(onPlayerSystemUpdate != null)
            UpdateIndicatorUI.instance.SetUpdateUI(_updateDataModel);
	}

    void onEnemyDestroyed(EnemyBehaviourBase enemyBehaviour)
    {
        _requiredEnemyForCurrentWave = _requiredEnemyForCurrentWave - 1;

        if (_requiredEnemyForCurrentWave <= 0)
            ActionUpdate();
    }

    public void OnTimeCompleted()
    {
        if (_requiredEnemyForCurrentWave <= 0 && _currentWaveNumber > 1)
            ActionUpdate();

        else if (_requiredEnemyForCurrentWave > 0 && _currentWaveNumber > 1)
            ActionDegrade();
    }


    #region DataReset

    private void OnGameStateChange(GameEnum.GameState gameState)
    {
        if(gameState == GameEnum.GameState.Running)
        {
            _timer.ResumeTimer();
        }
        if(gameState == GameEnum.GameState.PauseGame)
            _timer.PauseTimer();
    }

    private void ResetUpdate()
    {
        int savedTime = (int)(_requiredTimeForCurrentWave - _timer.GetElapsedTime());
        if (savedTime > 0 && _currentWaveNumber > 2 && _currentWaveNumber <= _maxWaveNum)
        {
			if (savedTime > ((int) this._requiredTime / 3))
				savedTime =(int) this._requiredTime / 3;
			_requiredTimeForCurrentWave = _requiredTimeForCurrentWave + savedTime;
            UpdateIndicatorUI.instance.ShowSavedTimeMesage(savedTime);
        }
          
        _requiredEnemyForCurrentWave = _requiredEnemy + (int)((_currentWaveNumber-1)* _updateFactor);
        _timer.StartTimer(_requiredTimeForCurrentWave);

        ResetUpdateDataModel();
    }
	private void ResetUpdateDataModel()
	{
		float remainingTime = _requiredTimeForCurrentWave - _timer.GetElapsedTime() ;

        _updateDataModel.remainingEnemyEnemyNumber = _requiredEnemyForCurrentWave;
        _updateDataModel.remainingTimeInSec = remainingTime;
		_updateDataModel.currentUpdateWave = _currentWaveNumber;
        _updateDataModel.totalEnemyRequired = _requiredEnemy;
        _updateDataModel.totalTimeRequired = _requiredTime;

        if (_currentWaveNumber >= _maxWaveNum)
            _updateDataModel.isItMaxUpdateWave = true;
        else
            _updateDataModel.isItMaxUpdateWave = false;
    }

    #endregion DataReset

    #region UpdateAction

    private void ActionUpdate()
    {
        if (onPlayerSystemUpdate == null)
            return;

        _currentWaveNumber = _currentWaveNumber + 1;

        if (_currentWaveNumber > _maxWaveNum)
            _currentWaveNumber = _maxWaveNum;

        onPlayerSystemUpdate(GameEnum.UpgradeType.AddGun);

        ResetUpdate();
    }
    private void ActionDegrade()
    {
        if (onPlayerSystemUpdate == null)
            return;

        _currentWaveNumber = _currentWaveNumber - 1;
        if (_currentWaveNumber <= 1)
            _currentWaveNumber = 1;

        onPlayerSystemUpdate(GameEnum.UpgradeType.RemoveGun);

        ResetUpdate();
    }

    #endregion UpdateAction

}
