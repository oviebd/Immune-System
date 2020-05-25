using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameUiPanel : PanelBase
{
	[SerializeField] private GameObject _PauseButton;
	[SerializeField] private SliderUtility _healthSlider;
	[SerializeField] private SliderUtility _levelProgressSlider;
	[SerializeField] private Animator _healthPanelAnimator;

	[SerializeField] private Text _levelNumberText;
	[SerializeField] private Text _scoreText;

	private string _anim_param_healthSlider_isShowingScale = "isShowingScale";

	private void Awake()
	{
		GameManager.onGameStateChange += OnGameStateChanged;
		Health.onHealthValueChanged += OnHealthValueChanged;
		ScoreManager.onScoreUpdate += OnScoreValueChanged;
		GameDataHandler.onGameLevelChange += ShowLevelNumber;
		WinningConditionHandler.onWinningVariableUpdated += SetlevelProgress;
	}
	private void OnDestroy()
	{
		GameManager.onGameStateChange -= OnGameStateChanged;
		Health.onHealthValueChanged -= OnHealthValueChanged;
		ScoreManager.onScoreUpdate -= OnScoreValueChanged;
		GameDataHandler.onGameLevelChange -= ShowLevelNumber;
		WinningConditionHandler.onWinningVariableUpdated -= SetlevelProgress;
	}

	
	void ShowLevelNumber(int levelNumber)
	{
		_levelNumberText.text = "L - " + levelNumber;
	}

	private void OnHealthValueChanged(int currentHealth, int maxHealth)
	{
		SetHealth(maxHealth, currentHealth);
	}
	private void SetHealth(float maxValue, float currentValue)
	{
		_healthSlider.SetMaxLimit(maxValue);
		_healthSlider.SetSliderValue(currentValue);

		if (currentValue <= (maxValue / 2))
			_healthPanelAnimator.SetBool(_anim_param_healthSlider_isShowingScale, true);
		else
			_healthPanelAnimator.SetBool(_anim_param_healthSlider_isShowingScale, false);
	}

	private void OnScoreValueChanged(int score)
	{
		_scoreText.text = score.ToString();
	}

	private void SetlevelProgress(int currentValue)
	{
		_levelProgressSlider.SetMaxLimit( (WinningConditionHandler.instance.GetWinningVariableValue() * 1.0f));
		_levelProgressSlider.SetSliderValue( (currentValue * 1.0f));
	}

	public void PauseButtonOnClicked()
	{
		GameActionHandler.instance.ActionPauseGame();
	}

	private void OnGameStateChanged(GameEnum.GameState state)
	{
		if(state == GameEnum.GameState.Idle || state == GameEnum.GameState.PlayerWin || state == GameEnum.GameState.PlayerLose)
		{
			_healthSlider.ResetData();
			_levelProgressSlider.ResetData();

		}
		if (state == GameEnum.GameState.TutorialState)
			_PauseButton.SetActive(false);
		else
			_PauseButton.SetActive(true);
	}
}
