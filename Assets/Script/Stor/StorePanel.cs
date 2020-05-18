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

    public void ShowItemInfo(StoreItemModel data)
    {
		_currentStoreItem = data;
		IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
        dialog.SetTitle(data.itemType.ToString());
        dialog.SetMessage(GetStoreItemDetailsBasedOnType(data.itemType));
    }

    public void BuyButtonClicked(StoreItemModel data)
    {
		_currentStoreItem = data;

		if(PlayerAchivedDataHandler.instance.GetTotalScore() >= data.price)
		{
			// User Can Buy
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
			dialog.SetDialogDelegate(this);
			dialog.SetTitle("Buy Item");
			dialog.SetMessage(data.itemName + "will cost  " + data.price + " " + " Point .\n Are You Sure to Purchase This ?" );
		}
		else
		{
			//Can not buy
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ErrorDialog);
			dialog.SetTitle("Low Point ! ");
			dialog.SetMessage("Not enough Point for Purchased this item");
		}
    }
	public void UseButtonClicked(StoreItemModel data)
	{
		_currentStoreItem = data;
		GameDataHandler.instance.SetCurrentPlayer(data.itemType);

		IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
		dialog.SetTitle("Congratulations!");
		dialog.SetMessage( "Player Set Cuccessfully");
	}
	public void OnDialogPositiveButtonPressed()
	{
		if (_currentStoreItem == null)
			return;
		
		if( PurchaseItem (_currentStoreItem) == true)
		{
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
			dialog.SetTitle("Purchase Confirmation");
			dialog.SetMessage(" Congratulations !  .\n Are You Successfully Purchased the item.");
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


	private string GetStoreItemDetailsBasedOnType(GameEnum.PlayerType type)
    {
		string details = "";
		GameObject playerObj = PlayerSpawnerController.instance.GetSpecificPlayerBasedOnType(type);
		PlayerController controller = playerObj.GetComponent<PlayerController>();
		if (controller == null)
			return details;
		details = controller.getPlayerDetails();

		return details;
    }

	
}
