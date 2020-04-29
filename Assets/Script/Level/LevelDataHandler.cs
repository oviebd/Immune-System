using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{
    public static LevelDataHandler instance;
    
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
    public int getMaxLevelNumber()
    {
        return _maxLevelnumber;
    }

}
