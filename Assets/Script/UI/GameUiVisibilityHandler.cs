using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUiVisibilityHandler : MonoBehaviour
{
	public static GameUiVisibilityHandler instance;

	[SerializeField] private OnGameUiPanel _onGameUiPanel;
	[SerializeField] private GameMainMenu _mainGamePanel;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void SetMainGameUI()
	{
		HideAllPanel();
		_mainGamePanel.gameObject.SetActive(true);
		_mainGamePanel.SetGameMainMenu();
	}
	public void SetOnGameUI()
	{
		HideAllPanel();
		_onGameUiPanel.ShowPanelObj();
	}

	void HideAllPanel()
	{
		_onGameUiPanel.HidePanelObj ();
		_mainGamePanel.gameObject.SetActive(false);
	}
	
}
