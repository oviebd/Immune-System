using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelPanel : PanelBase
{
    public static SelectLevelPanel instance;
    [SerializeField] private SelectLevelItemHandler levelListItemHandler;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Setup()
    {
        levelListItemHandler.Setup();
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
