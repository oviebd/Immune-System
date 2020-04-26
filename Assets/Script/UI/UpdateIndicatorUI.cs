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
		int remainingEnemyNum = dataModel.remainingEnemyEnemyNumber; //- dataModel.currentEnemyNumber;
		//Debug.Log("Current Update num : " + dataModel.currentUpdateWave);
		string statusText = "";
		if (dataModel.currentUpdateWave <= 1)
			statusText = "Destroy " + remainingEnemyNum + " Enemy for get more firepower";
		else if (dataModel.currentUpdateWave > 1 && dataModel.isItMaxUpdateWave == false)
			statusText = "Destroy " + remainingEnemyNum + " Enemy within " + (int)dataModel.remainingTimeInSec + " second \nfor get more firepower Otherwise You Lose Firepower";
		else
			statusText = "Destroy " + remainingEnemyNum + " Enemy within " + (int)dataModel.remainingTimeInSec + " second \nOtherwise You Lose Firepower";

		_updateStatus.text = statusText;
	}

}
