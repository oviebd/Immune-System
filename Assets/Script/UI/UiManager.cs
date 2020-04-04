using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
	public static UiManager instance;
	[SerializeField] private SliderUtility _healthSlider;
	[SerializeField] private SliderUtility _nextLevelIndicatorSlider;

	private GameEnum.UiState _currentUiState;
	public delegate void UIStateChange(GameEnum.UiState UIState);
	public static event UIStateChange onUiStateChanged;
	private void Awake()
	{
		if (instance == null)
			instance = this;
		GameManager.onGameStateChange += OnChangeGameState;
	}
	private void OnDestroy()
	{
		GameManager.onGameStateChange += OnChangeGameState;
	}
	public void SetUIState(GameEnum.UiState uiState)
	{
		_currentUiState = uiState;
		if (onUiStateChanged != null)
			onUiStateChanged(_currentUiState);
	}
	public GameEnum.UiState GetCurrentUiState()
	{
		return _currentUiState;
	}
	void OnChangeGameState(GameEnum.GameState gameState)
	{
		switch (gameState)
		{
			case GameEnum.GameState.Idle:
				GameUiVisibilityHandler.instance.SetMainGameUI();
				break;
			case GameEnum.GameState.Running:
				GameUiVisibilityHandler.instance.SetOnGameUI();
				UiManager.instance.SetUIState(GameEnum.UiState.GameRunningState);
				break;
			case GameEnum.GameState.PauseGame:
				UiManager.instance.SetUIState(GameEnum.UiState.PauseGameState);
				GameUiVisibilityHandler.instance.SetMainGameUI();
				break;
			case GameEnum.GameState.GameOver:
				SetUIState(GameEnum.UiState.GameOverState);
				GameUiVisibilityHandler.instance.SetMainGameUI();
				break;
		}
	}

	public void UpdateHealthSlider(float maxValue, float currentValue)
	{
		_healthSlider.SetMaxLimit(maxValue);
		_healthSlider.SetSliderValue(currentValue);
	}

	public void UpdateNextLevelIndicatorSlider(float maxValue, float currentValue)
	{
		_nextLevelIndicatorSlider.SetMaxLimit(maxValue);
		_nextLevelIndicatorSlider.SetSliderValue(currentValue);
	}


}
