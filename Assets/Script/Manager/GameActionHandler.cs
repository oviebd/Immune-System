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
		GameStateTracker.instance.PushGameState(GameEnum.GameState.Idle);
		UiManager.instance.SetUIState(GameEnum.UiState.StartGameState);
	}
	public void ActionSelectLevel()
	{
		GameStateTracker.instance.PushGameState(GameEnum.GameState.LevelChoose);
	}
	public void ActionShowStore()
	{
		GameStateTracker.instance.PushGameState(GameEnum.GameState.StoreUiState);
	}
	public void ActionPlayGame(int levelNumber)
	{
		//Time.timeScale = 1;
		GameStateTracker.instance.PushGameState(GameEnum.GameState.Running);
		LevelManager.instance.LoadALevel(levelNumber);
	}
	public void ActionPauseGame()
	{
		GameStateTracker.instance.PushGameState(GameEnum.GameState.PauseGame);
		GameEnvironmentController.instance.HideAllInstantiatedObjs();
		//Time.timeScale = 0;
	}
	public void ActionResumeGame()
	{
		GameStateTracker.instance.PushGameState(GameEnum.GameState.Running);
		GameEnvironmentController.instance.ShowAllInstantiatedObjs();
		//Time.timeScale = 1;
	}
	public void ActionNextLevelGame()
	{
		ActionPlayGame(LevelManager.instance.GetCurrentLevelNumber()+1);
	}
	public void ActionGoMainMenu()
	{
		GameStateTracker.instance.PushGameState(GameEnum.GameState.Idle);
	}
	public void ActionRetryGame()
	{
		ActionPlayGame(LevelManager.instance.GetCurrentLevelNumber());
	}
	public void ActionShowTutorial()
	{
		GameStateTracker.instance.PushGameState(GameEnum.GameState.TutorialState);
		GameEnvironmentController.instance.SetEnvironmentForTutorial();
	}
	public void ActionGameOver(bool isWin)
	{
		GameEnvironmentController.instance.HideAllInstantiatedObjs();
		GameStateTracker.instance.PushGameState(GameEnum.GameState.PlayerLose);
		if (isWin)
			GameStateTracker.instance.PushGameState(GameEnum.GameState.PlayerWin);
		else
			GameStateTracker.instance.PushGameState(GameEnum.GameState.PlayerLose);
	}


    public void BackButtonPressed()
    {
		GameStateTracker.instance.PopGameState();
	}
}
