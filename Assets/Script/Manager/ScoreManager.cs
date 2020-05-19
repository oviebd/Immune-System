using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int _winningScore = 50;
    private int _currentScore = 0;

    public delegate void OnPlayerWinDelegate();
    public static event OnPlayerWinDelegate onPlayerWin;

	public delegate void OnScoreUpdate(int score);
	public static event OnScoreUpdate onScoreUpdate;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }
    public void SetWInningPoint(int winningPoint)
    {
        _winningScore = winningPoint;
        _currentScore = 0;
		onScoreUpdate(_currentScore);
	}
    public void AddScore(int incrementedScore)
    {
        _currentScore = _currentScore + incrementedScore;

		if (IsPlayerWin())
		{
			int totalScore = PlayerAchivedDataHandler.instance.GetTotalScore() + _currentScore;
			PlayerAchivedDataHandler.instance.SetTotalScore(totalScore);
			onPlayerWin();
		}

		onScoreUpdate(_currentScore);
	}

    bool IsPlayerWin()
    {
        if (_currentScore >= _winningScore)
            return true;
        else
            return false;
    }
}
