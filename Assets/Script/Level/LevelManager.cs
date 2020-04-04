using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private int _currentLevel = 2;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        ScoreManager.onPlayerWin += OnlevelCompleted;
    }

    void Start()
    {
        LoadALevel(_currentLevel);
    }

    public void LoadALevel(int levelNumber)
    {
        GameEnvironmentController.instance.LoadLebvelEnvironment(levelNumber);
        ScoreManager.instance.SetWInningPoint(LevelDataHandler.instance.GetWinningPointOfALevel(levelNumber));
    }


    void OnlevelCompleted()
    {
       // _currentLevel = _currentLevel + 1;
        Debug.Log("Level Completed....Prev Level  " + _currentLevel);
    }

    public int GetCurrentLevelNumber()
    {
        return _currentLevel;
    }
    public void SetCurrentLevelNumber(int levelNumber)
    {
        _currentLevel = levelNumber;
    }

}
