using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionHandler : MonoBehaviour
{
	public static GameActionHandler instance;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void GameInitialAction()
	{
		GameManager.instance.SetGameState(GameEnum.GameState.Idle);
		UiManager.instance.SetUIState(GameEnum.UiState.StartGameState);
	}
	public void ActionSelectLevel()
	{
		GameManager.instance.SetGameState(GameEnum.GameState.LevelChoose);
	}
	public void ActionShowStore()
	{
		GameManager.instance.SetGameState(GameEnum.GameState.StoreUiState);
	}
	public void ActionPlayGame(int levelNumber)
	{
		Time.timeScale = 1;
		GameManager.instance.SetGameState(GameEnum.GameState.Running);
		LevelManager.instance.LoadALevel(levelNumber);
	}
	public void ActionPauseGame()
	{
		GameManager.instance.SetGameState(GameEnum.GameState.PauseGame);
		GameEnvironmentController.instance.HideAllInstantiatedObjs();
		Time.timeScale = 0;
	}
	public void ActionResumeGame()
	{
		GameManager.instance.SetGameState(GameEnum.GameState.Running);
		GameEnvironmentController.instance.ShowAllInstantiatedObjs();
		Time.timeScale = 1;
	}
	public void ActionNextLevelGame()
	{
		ActionPlayGame(LevelManager.instance.GetCurrentLevelNumber()+1);
	}
	public void ActionGoMainMenu()
	{
		GameManager.instance.SetGameState(GameEnum.GameState.Idle);
	}
	public void ActionRetryGame()
	{
		ActionPlayGame(LevelManager.instance.GetCurrentLevelNumber());
	}

	public void ActionGameOver(bool isWin)
	{
		GameEnvironmentController.instance.HideAllInstantiatedObjs();
		GameManager.instance.SetGameState(GameEnum.GameState.PlayerLose);
		if (isWin)
			GameManager.instance.SetGameState(GameEnum.GameState.PlayerWin);
		else
			GameManager.instance.SetGameState(GameEnum.GameState.PlayerLose);
	}


    public void BackButtonPressed()
    {

    }
}
