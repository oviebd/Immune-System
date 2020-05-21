using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePanel : PanelBase,DialogBase.Delegate
{
    public static StorePanel instance;
    [SerializeField] private StoreListItemHandler storeListItemHandler;

	private StoreItemModel _currentStoreItem;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Setup()
    {
        storeListItemHandler.Setup();
    }

    public void BuyButtonClicked(StoreItemModel data)
    {
		_currentStoreItem = data;

		if(PlayerAchivedDataHandler.instance.GetTotalScore() >= data.price)
		{
			// User Can Buy
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
			dialog.SetDialogDelegate(this);
			dialog.SetTitle("Purchase Item !");
			dialog.SetMessage(data.itemName + " will cost  " + data.price  + " Point .\n Want to purchase?" );
		}
		else
		{
			//Can not buy
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ErrorDialog);
			dialog.SetTitle("Not enough Point ! ");
			dialog.SetMessage("Not enough Point for Purchased this item");
		}
    }
	public void UseButtonClicked(StoreItemModel data)
	{
		_currentStoreItem = data;
		GameDataHandler.instance.SetCurrentPlayer(data.itemType);
		storeListItemHandler.Setup();
	}
	public void OnDialogPositiveButtonPressed()
	{
		if (_currentStoreItem == null)
			return;
		
		if( PurchaseItem (_currentStoreItem) == true)
		{
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
			dialog.SetTitle("Purchase Confirmation");
			dialog.SetMessage(" Congratulations !  .\n  You Successfully Purchased the item.");
			storeListItemHandler.Setup();
		}
	}

	public void CrossButtonClicked()
	{
		HidePanelObj();
		GameActionHandler.instance.BackButtonPressed();
	}

	private bool PurchaseItem(StoreItemModel data)
	{
		int afterPurchasePoint = PlayerAchivedDataHandler.instance.GetTotalScore() - data.price;
		if(afterPurchasePoint >= 0)
		{
			PlayerAchivedDataHandler.instance.InsertPlayerShipInAchivedList(data.itemType);
			PlayerAchivedDataHandler.instance.SetTotalScore(afterPurchasePoint);
			return true;
		}
		return false;
	}

	
}
