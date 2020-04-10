using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelPanel : PanelBase
{
    [SerializeField] private List<Button> _buttonList;
    //private int _currentLevel = 1;

    public void Setup()
    {
        SetupUI();
    }

    private void SetupUI()
    {
        for(int i = 0; i < _buttonList.Count; i++)
        {
            Button button = _buttonList[i];
            if (i >= (PlayerAchivedDataHandler.instance.GetMaxCompletedLevelNumber()))
                button.interactable = false;
            else
                button.interactable = true;
        }
    }

    public void LevelButtonClick(int levelNum)
    {
        GameActionHandler.instance.ActionPlayGame(levelNum);
    }

    public void BackButtonOnClick()
    {
        GameActionHandler.instance.BackButtonPressed();
    }

}
