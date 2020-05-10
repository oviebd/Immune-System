using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateIndicatorUI : PanelBase
{
	public static UpdateIndicatorUI instance;
	[SerializeField] private Text _updateStatus;
	[SerializeField] private Image _filledIndicatorImage;
	[SerializeField] private Text _remainingEnemyText;
	[SerializeField] private Text _remainingTimeText;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void SetUpdateUI( PlayerUpdateModel dataModel )
	{
		if (dataModel == null)
			return;

		if (dataModel.currentUpdateWave > 1)
        {
			float timeFactor = (dataModel.remainingTimeInSec / dataModel.totalTimeRequired);
			_filledIndicatorImage.fillAmount = timeFactor;
			_remainingTimeText.text = (int) dataModel.remainingTimeInSec + " s";
        }
        else
        {
			_filledIndicatorImage.fillAmount = 1.0f;
			_remainingTimeText.text = "";
		}

		_remainingEnemyText.text = dataModel.remainingEnemyEnemyNumber + "";
	}


	public void ShowSavedTimeMesage(int savedTime)
	{
		GameUiVisibilityHandler.instance.ShowAnimatedMessage("You have saved " + savedTime + " s");
	}

}
