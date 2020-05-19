using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameUiPanel : PanelBase
{
	[SerializeField] private GameObject _PauseButton;

	[SerializeField] private SliderUtility _healthSlider;
	[SerializeField] private Animator _healthPanelAnimator;

	private string _anim_param_healthSlider_isShowingScale = "isShowingScale";
	private void Awake()
	{
		GameManager.onGameStateChange += OnGameStateChanged;
	}
	private void OnDestroy()
	{
		GameManager.onGameStateChange -= OnGameStateChanged;
	}

	public void SetHealth(float maxValue, float currentValue)
	{
		_healthSlider.SetMaxLimit(maxValue);
	    _healthSlider.SetSliderValue(currentValue);

		if(  currentValue <= (maxValue/2))
		{
			_healthPanelAnimator.SetBool(_anim_param_healthSlider_isShowingScale, true);
		}else
			_healthPanelAnimator.SetBool(_anim_param_healthSlider_isShowingScale, false);
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
		}

		if (state == GameEnum.GameState.TutorialState)
			_PauseButton.SetActive(false);
		else
			_PauseButton.SetActive(true);
	}
}
