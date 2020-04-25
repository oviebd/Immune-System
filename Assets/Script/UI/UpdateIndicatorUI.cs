using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateIndicatorUI : PanelBase
{
	public static UpdateIndicatorUI instance;
	[SerializeField] private Text _updateStatus;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void SetUpdateUI( PlayerUpdateModel dataModel )
	{
		int remainingEnemyNum = dataModel.requiredEnemyNumber - dataModel.currentEnemyNumber;
		Debug.Log("Current Update num : " + dataModel.currentUpdateWave);
		dataModel.isItMaxUpdateWave = false;
		string statusText = "";
		if (dataModel.currentUpdateWave <= 0)
			statusText = "Destroy " + remainingEnemyNum + " Enemy";
		else if (dataModel.currentUpdateWave > 0 && dataModel.isItMaxUpdateWave == false)
			statusText = "Destroy " + remainingEnemyNum + " Enemy within " + (int)dataModel.remainingTimeInSec + " second for get more firepower Otherwise You Lose Firepower";
		else
			statusText = "Destroy " + remainingEnemyNum + " Enemy  Or You Lose your firePower";

		_updateStatus.text = statusText;
	}

}
