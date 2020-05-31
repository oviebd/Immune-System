using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : PanelBase
{
	private string _winningMessage = "Congratulations ! \n You completed this level";
	private string _loseMessage = "You Lost ! \n Please Try Again Harder";

	[SerializeField] private Text _messageText;
	[SerializeField] private Button _retryButton;
	[SerializeField] private Button _nextLevelButton;

	public void SetUpGameOverPanel()
	{
		if(GameManager.instance.GetCurrentGameState() == GameEnum.GameState.PlayerWin)
			setPlayerWinPanel();
		if (GameManager.instance.GetCurrentGameState() == GameEnum.GameState.PlayerLose)
			setPlayerLosePanel();
	}

	private void setPlayerWinPanel()
	{
		HideAllButton();

        if(LevelManager.instance.GetCurrentLevelNumber() < GameDataHandler.instance.getMaxLevelNumber())
			GameUiVisibilityHandler.instance.ShowAButton(_nextLevelButton);

        _messageText.text = _winningMessage;

	}
	private void setPlayerLosePanel()
	{
		_messageText.text = _loseMessage;
		HideAllButton();
		GameUiVisibilityHandler.instance.ShowAButton(_retryButton);
	}

	private void HideAllButton()
	{
		GameUiVisibilityHandler.instance.HideAButton(_nextLevelButton);
		GameUiVisibilityHandler.instance.HideAButton(_retryButton);
	}

	#region Button Events
	public void PlayNextLevelButtonOnClicked()
	{
		GameActionHandler.instance.ActionNextLevelGame();
	}
	public void MainMenuButtonOnClicked()
	{
		GameActionHandler.instance.ActionGoMainMenu();
	}
	public void RetryGameButtonOnClicked()
	{
		GameActionHandler.instance.ActionRetryGame();
	}
	public void ChooseLevelButtonOnClicked()
	{
		GameActionHandler.instance.ActionSelectLevel();
	}

	#endregion Button Events

}
