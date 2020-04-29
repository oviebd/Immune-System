using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataHandler : MonoBehaviour
{
    public static GameDataHandler instance;

    [SerializeField] private GameDataScriptable _gameDataScriptable;
    [SerializeField] private List<int> _winningPointPerLevel;
    [SerializeField] private int _maxLevelnumber = 2;

   private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public int GetWinningPointOfALevel(int levelNumbere)
    {
        levelNumbere = levelNumbere - 1;
        if (_winningPointPerLevel != null && levelNumbere < _winningPointPerLevel.Count)
            return _winningPointPerLevel[levelNumbere];

        else return 0;
    }

    public int GetCurrentLevelNumber()
    {
        if (_gameDataScriptable == null)
            return 1;
        else
            return _gameDataScriptable.currentLevel;
    }

    public void SetCurrentLevelNumber(int levelNumber)
    {
        if (_gameDataScriptable == null)
            return;
        _gameDataScriptable.currentLevel = levelNumber;
    }

    public bool IsTutorialShown()
    {
        if (_gameDataScriptable == null)
            return false;
        else
            return _gameDataScriptable.isTutorialShown;
    }

    public void SetTutorialStatusShown()
    {
        if (_gameDataScriptable == null)
            return;
        _gameDataScriptable.isTutorialShown = true;
    }

    public int getMaxLevelNumber()
    {
        return _maxLevelnumber;
    }

}
