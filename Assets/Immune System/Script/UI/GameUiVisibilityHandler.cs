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
	[SerializeField] private StorePanel _storeUi;
	[SerializeField] private SelectLevelPanel _chooseLevelPanel;

	[SerializeField] private SliderUtility _nextLevelIndicatorSlider;
	[SerializeField] private GameObject _animatedMessagePrefab;

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

	public void SetStorerUI()
	{
		HideAllPanel();
		_storeUi.ShowPanelObj();
		_storeUi.Setup();
	}
	public void SetChooseLevelUI()
	{
		HideAllPanel();
		_chooseLevelPanel.ShowPanelObj();
		_chooseLevelPanel.Setup();
	}

	void HideAllPanel()
	{
		_onGameUi.HidePanelObj ();
		_mainGameUi.HidePanelObj();
		_gameOverUi.HidePanelObj();
		_storeUi.HidePanelObj();
		_chooseLevelPanel.HidePanelObj();
	}

	public void ShowAButton(Button button)
	{
		button.gameObject.SetActive(true);
	}
	public void HideAButton(Button button)
	{
		button.gameObject.SetActive(false);
	}
	public GameObject ShowAnimatedMessage(string message,GameObject parent = null)
	{
		GameObject obj;
		if(parent == null)
			obj = InstantiatorHelper.instance.InstantiateCanvasUIObject(_animatedMessagePrefab);
		else
			obj = InstantiatorHelper.instance.InstantiateCanvasUIObject(_animatedMessagePrefab, parent);

		if (obj.GetComponent<AnimatedMessage>() !=null)
			obj.GetComponent<AnimatedMessage>().SetMessage(message);

		return obj;
	}

    public void ShowTutorial()
    {
		TutorialManager.instance.ShowTutorial();
		SetOnGameUI();
    }

}
