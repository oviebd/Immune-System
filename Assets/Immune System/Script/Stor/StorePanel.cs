using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePanel : PanelBase,DialogBase.Delegate
{
    public static StorePanel instance;
    [SerializeField] private StoreListItemHandler storeListItemHandler;
	[SerializeField] private Button _adButton;

	private StoreItemModel _currentStoreItem;

    private enum actionDialogType { PurchaseType,AdType }
	private actionDialogType currentActiondialogType;

    private string rewardAdMessage = "";
	private bool _isRewardAdLoaded = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;

		//RewardAdController.onRewardAdLoaded += OnChangeRewardAdLoadedStatus;
	}

    private void OnDestroy()
    {
		//RewardAdController.onRewardAdLoaded -= OnChangeRewardAdLoadedStatus;
	}

    public void Setup()
    {
		//rewardAdMessage = "You can earn " + RewardAdController.instance.GetRewardPoint() + " points by watching ad. \n Want to watch Ad ?";

		storeListItemHandler.Setup();

        /*if(RewardAdController.instance.IsRewardAdLoaded() == true)
			ShowRewardAdDialog();*/
	}

    public void BuyButtonClicked(StoreItemModel data)
    {
		_currentStoreItem = data;

		if(PlayerAchivedDataHandler.instance.GetTotalScore() >= data.price)
		{
			// User Can Buy
			currentActiondialogType = actionDialogType.PurchaseType;
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
			dialog.SetDialogDelegate(this);
			dialog.SetTitle("Purchase Item !");
			dialog.SetMessage(data.itemName + " will cost  " + data.price  + " Point .\n Want to purchase?" );
		}
		else
		{
            //UnComment When Google admob implemented
			//Can not buy
			/* if(RewardAdController.instance.IsRewardAdLoaded() == true)
			 {
				 currentActiondialogType = actionDialogType.AdType;
				 IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
				 dialog.SetTitle("Not enough Point ! ");
				 dialog.SetMessage(rewardAdMessage);
			 }else
			 {
				 IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ErrorDialog);
				 dialog.SetTitle("Not enough Point ! ");
				 dialog.SetMessage("You have not enough point for purchage this item !");
			 }*/

			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ErrorDialog);
			dialog.SetTitle("Not enough Point ! ");
			dialog.SetMessage("You have not enough point for purchage this item !");

		}
    }
	public void UseButtonClicked(StoreItemModel data)
	{
		_currentStoreItem = data;
		GameDataHandler.instance.SetCurrentPlayer(data.itemType);
		storeListItemHandler.Setup();
	}

	public void CrossButtonClicked()
	{
		HidePanelObj();
		GameActionHandler.instance.BackButtonPressed();
	}

	public void OnDialogPositiveButtonPressed()
	{
		if (currentActiondialogType == actionDialogType.PurchaseType)
		{
			if (_currentStoreItem == null)
				return;

			if (PurchaseItem(_currentStoreItem) == true)
			{
				IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
				dialog.SetTitle("Purchase Confirmation");
				dialog.SetMessage(" Congratulations !  .\n  You Successfully Purchased the item.");
				storeListItemHandler.Setup();
			}
		}
		if (currentActiondialogType == actionDialogType.AdType)
		{
			ShowRewardAdButtonClicked();
		}

	}

	public void ShowRewardAdButtonClicked()
	{
		//AdManager.instance.ShowRewardAd();
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

	
    /*private void ShowRewardAdDialog()
    {
		currentActiondialogType = actionDialogType.AdType;

        IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
		dialog.SetDialogDelegate(this);
		dialog.SetTitle("Get Point!");
		dialog.SetMessage(rewardAdMessage);
	}

    private void OnChangeRewardAdLoadedStatus(bool isLoaded)
    {
		_isRewardAdLoaded = isLoaded;
	}*/
}
