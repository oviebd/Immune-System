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


	[SerializeField] private Animator _remainingTimeAnimator;
	private string anim_param_remainingTime_isShowingScale = "isShowingScale";
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

			if (dataModel.remainingTimeInSec <= dataModel.totalTimeRequired / 2)
			{
				_remainingTimeAnimator.SetBool(anim_param_remainingTime_isShowingScale, true);
			}
			else
				_remainingTimeAnimator.SetBool(anim_param_remainingTime_isShowingScale, false);
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
		_remainingTimeAnimator.SetBool(anim_param_remainingTime_isShowingScale, false);
		GameObject animatedObj =  GameUiVisibilityHandler.instance.ShowAnimatedMessage("+ " + savedTime + " s" , _remainingTimeText.gameObject);
		if(animatedObj != null && animatedObj.GetComponent<RectTransform>() !=null )
			animatedObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 0);
	}

}
