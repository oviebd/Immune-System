using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUiVisibilityHandler : MonoBehaviour
{
	public static GameUiVisibilityHandler instance;

	[SerializeField] private OnGameUiPanel _onGameUi;
	[SerializeField] private GameMainMenu _mainGameUi;
	[SerializeField] private GameOverMenu _gameOverUi;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void SetMainGameUI()
	{
		HideAllPanel();
		_mainGameUi.ShowPanelObj();
		_mainGameUi.SetGameMainMenu();
	}
	public void SetOnGameUI()
	{
		HideAllPanel();
		_onGameUi.ShowPanelObj();
	}
	public void SetGameOverUI()
	{
		HideAllPanel();
		_gameOverUi.ShowPanelObj();
		_gameOverUi.SetUpGameOverPanel();
	}

	void HideAllPanel()
	{
		_onGameUi.HidePanelObj ();
		_mainGameUi.HidePanelObj();
		_gameOverUi.HidePanelObj();
	}
	public void ShowAButton(Button button)
	{
		button.gameObject.SetActive(true);
	}
	public void HideAButton(Button button)
	{
		button.gameObject.SetActive(false);
	}

}
