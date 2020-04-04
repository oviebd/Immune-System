using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameUiPanel : PanelBase
{
	public void PauseButtonOnClicked()
	{
		GameActionHandler.instance.ActionPauseGame();
	}
}
