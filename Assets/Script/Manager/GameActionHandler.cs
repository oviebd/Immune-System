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
	public void ActionStartGame()
	{
		Time.timeScale = 1;
		GameManager.instance.SetGameState(GameEnum.GameState.Running);
		LevelManager.instance.LoadALevel(LevelManager.instance.GetCurrentLevelNumber());
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
	public void ActionRetryGame()
	{
		ActionStartGame();
	}
}
