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

    public Text scoreText;

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
		
		updateUI();
    }
    public void AddScore(int incrementedScore)
    {
        _currentScore = _currentScore + incrementedScore;

        scoreText.text = "S:" + _currentScore;
        if (IsPlayerWin())
            onPlayerWin();
		updateUI();
	}

    bool IsPlayerWin()
    {
        if (_currentScore >= _winningScore)
            return true;
        else
            return false;
    }
	private void updateUI()
	{
		UiManager.instance.UpdateNextLevelIndicatorSlider(_winningScore*1.0f, _currentScore*1.0f);
	}
    
}
