using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainMenu : PanelBase
{
	public static GameMainMenu instance;

	[SerializeField] private Button _startNewGameButton;
	[SerializeField] private Button _resumeGameButton;
	[SerializeField] private Button _retryGameButton;
	[SerializeField] private Button _chooseLevelGameButton;
	[SerializeField] private Button _goMainMenuButton;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void SetGameMainMenu()
	{
		GameEnum.UiState uiState = UiManager.instance.GetCurrentUiState();
		switch (uiState)
		{
			case GameEnum.UiState.StartGameState:
				SetStartNewGameUI();
				break;
			case GameEnum.UiState.PauseGameState:
				SetPauseGameUI();
				break;
		}
	}
	void SetStartNewGameUI()
	{
		HideAll();
		ShowAButton(_startNewGameButton);
		ShowAButton(_chooseLevelGameButton);
	}
	void SetPauseGameUI()
	{
		HideAll();
		ShowAButton(_resumeGameButton);
		ShowAButton(_retryGameButton);
		ShowAButton(_goMainMenuButton);
	}
	
	void HideAll()
	{
		HideAButton(_startNewGameButton);
		HideAButton(_resumeGameButton);
		HideAButton(_retryGameButton);
		HideAButton(_chooseLevelGameButton);
		HideAButton(_goMainMenuButton);
	}


	void ShowAButton(Button button)
	{
		button.gameObject.SetActive(true);
	}
	void HideAButton(Button button)
	{
		button.gameObject.SetActive(false);
	}

	#region Button Events
	public void StartGameButtonOnClicked()
	{
		GameActionHandler.instance.ActionPlayGame(LevelManager.instance.GetCurrentLevelNumber());
	}
	public void ResumeGameButtonOnClicked()
	{
		GameActionHandler.instance.ActionResumeGame();
	}
	public void RetryGameButtonOnClicked()
	{
		GameActionHandler.instance.ActionRetryGame();
	}
	public void ChooseLevelButtonOnClicked()
	{
		GameActionHandler.instance.ActionSelectLevel();
	}
	public void GoMainMenuButtonOnClicked()
	{
		UiManager.instance.SetUIState(GameEnum.UiState.StartGameState);
		GameActionHandler.instance.ActionGoMainMenu();
	}
	#endregion Button Events
}