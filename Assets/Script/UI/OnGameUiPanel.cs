using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameUiPanel : PanelBase
{
    

    [SerializeField] private GameObject _tutorialButton;
	[SerializeField] private GameObject _PauseButton;

    private void Awake()
    {
        UiManager.onUiStateChanged += onUiStateChanged;
    }
    private void OnDestroy()
    {
        UiManager.onUiStateChanged -= onUiStateChanged;
    }

    public void PauseButtonOnClicked()
	{
		GameActionHandler.instance.ActionPauseGame();
	}

	public void ShowTutorial()
	{
		GameActionHandler.instance.ActionShowTutorial();
	}

    void onUiStateChanged(GameEnum.UiState uiState)
    {
        if (this.isActiveAndEnabled == false)
            return;
       
        if(uiState == GameEnum.UiState.TutorialUiState)
        {
            _tutorialButton.SetActive(false);
            _PauseButton.SetActive(false);
        }else
        {
            _tutorialButton.SetActive(true);
            _PauseButton.SetActive(true);
        }

    }
}
