using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningConditionHandler : MonoBehaviour
{
    public static WinningConditionHandler instance;

    private int _currentValue = 0;
    private int _winningValue = 1000;


    public delegate void OnPlayerWinDelegate();
    public static event OnPlayerWinDelegate onPlayerWin;

    public delegate void OnWinningVariableUpdateDelegate(int amount);
    public static event OnWinningVariableUpdateDelegate onWinningVariableUpdated;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        EnemyBehaviourBase.enemyDestroyedByPlayer += OnIncrementWinningVariable;
        GameManager.onGameStateChange += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        EnemyBehaviourBase.enemyDestroyedByPlayer += OnIncrementWinningVariable;
        GameManager.onGameStateChange -= OnGameStateChanged;
    }

    public void SetWinningAmount(int amount)
    {
        _winningValue = amount;
        _currentValue = 0;
       
    }
    public int GetWinningVariableValue()
    {
        return _winningValue;
    }
    public int GetCurrentVariableValue()
    {
        return _currentValue;
    }

    private void OnIncrementWinningVariable(EnemyBehaviourBase enemyBehaviour)
    {
        _currentValue = _currentValue + 1;

        if (onWinningVariableUpdated != null)
            onWinningVariableUpdated(_currentValue);

        if (IsPlayerWin()) {

            int totalScore = PlayerAchivedDataHandler.instance.GetTotalScore() + ScoreManager.instance.GetCurrentScore();
            //Debug.Log("Total s  : " + totalScore + "Curr : " + ScoreManager.instance.GetCurrentScore() + " prev t : " + PlayerAchivedDataHandler.instance.GetTotalScore());

            PlayerAchivedDataHandler.instance.SetTotalScore(totalScore);
            if (onPlayerWin != null)
                onPlayerWin();
        }
    }

    bool IsPlayerWin()
    {
        if (_currentValue >= _winningValue)
            return true;
        else
            return false;
    }

    private void OnGameStateChanged(GameEnum.GameState state)
    {
        if (state == GameEnum.GameState.Idle || state == GameEnum.GameState.PlayerWin || state == GameEnum.GameState.PlayerLose)
        {
            _currentValue = 0;
            _winningValue = 1000;
        }
    }
}
