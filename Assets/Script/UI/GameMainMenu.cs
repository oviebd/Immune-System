using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainMenu : MonoBehaviour
{
	public static GameMainMenu instance;

	[SerializeField] private Button _startNewGameButton;
	[SerializeField] private Button _resumeGameButton;
	[SerializeField] private Button _retryGameButton;

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
			case GameEnum.UiState.GameOverState:
				SetGameOverUI();
				break;
		}
	}
	void SetStartNewGameUI()
	{
		HideAll();
		ShowAButton(_startNewGameButton);
	}
	void SetPauseGameUI()
	{
		HideAll();
		ShowAButton(_resumeGameButton);
		ShowAButton(_retryGameButton);
	}
	void SetGameOverUI()
	{
		HideAll();
		ShowAButton(_startNewGameButton);
	}
	void HideAll()
	{
		HideAButton(_startNewGameButton);
		HideAButton(_resumeGameButton);
		HideAButton(_retryGameButton);
	}


	void ShowAButton(Button button)
	{
		button.gameObject.SetActive(true);
	}
	void HideAButton(Button button)
	{
		button.gameObject.SetActive(false);
	}


	public void StartGameButtonOnClicked()
	{
		GameActionHandler.instance.ActionStartGame();
	}
	public void ResumeGameButtonOnClicked()
	{
		GameActionHandler.instance.ActionResumeGame();
	}
	public void RetryGameButtonOnClicked()
	{
		GameActionHandler.instance.ActionRetryGame();
	}
}