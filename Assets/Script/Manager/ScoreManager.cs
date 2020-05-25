using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

   // private int _winningScore = 50;
    private int _currentScore = 0;

	public delegate void OnScoreUpdate(int score);
	public static event OnScoreUpdate onScoreUpdate;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        GameManager.onGameStateChange += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChange -= OnGameStateChanged;
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }
    /* public void SetWInningPoint(int winningPoint)
     {
         _winningScore = winningPoint;
         _currentScore = 0;
         onScoreUpdate(_currentScore);
     }

     public int GetWinningScore()
     {
         return _winningScore;
     }*/

    public void AddScore(int incrementedScore)
    {
        _currentScore = _currentScore + incrementedScore;

        if(onScoreUpdate != null)
            onScoreUpdate(_currentScore);
    }

    private void OnGameStateChanged(GameEnum.GameState state)
    {
        if (state == GameEnum.GameState.Idle || state == GameEnum.GameState.PlayerWin || state == GameEnum.GameState.PlayerLose)
        {
            _currentScore = 0;
            AddScore(0);
        }
    }

}
