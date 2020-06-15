using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelItem : MonoBehaviour
{
	[SerializeField] private Text _txtLevelNumber;
	[SerializeField] private Text _txtDescription;
	[SerializeField] private Button _itemButton;

	private SelectLevelItemModel itemData;
	public void Setup(SelectLevelItemModel item)
	{
		this.itemData = item;
		SetupUi(item);
	}

	private void SetupUi(SelectLevelItemModel item)
	{
		if (item == null)
			return;

		_txtLevelNumber.text = "Level " + item.levelNumber ;
	   _txtDescription.text = item.levelDescription ;

		if (item.levelNumber > PlayerAchivedDataHandler.instance.GetMaxCompletedLevelNumber())
			_itemButton.interactable = false;
		else
			_itemButton.interactable = true;
	}

	public void OnItemButtonClicked()
	{
		SelectLevelPanel.instance.LevelButtonClick(this.itemData.levelNumber);
	}
}
