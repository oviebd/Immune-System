using System.Collections;
using System.Collections.Generic;
using SmileSoft_Ads_Manager;
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

		//rewardAdMessage = "You can earn " + 20 + " points by watching ad. \n Want to watch Ad ?";
		//OnChangeRewardAdLoadedStatus(false);
		//RewardAdController.onRewardAdLoaded += OnChangeRewardAdLoadedStatus;
	}

    //   private void OnDestroy()
    //   {
    //	RewardAdController.onRewardAdLoaded -= OnChangeRewardAdLoadedStatus;
    //}

    public void Setup()
    {
        rewardAdMessage = "You can earn " + 20 + " points by watching ad. \n Want to watch Ad ?";

        storeListItemHandler.Setup();

        //      if(RewardAdController.instance.IsRewardAdLoaded() == true)
        //	ShowRewardAdDialog();
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


			//Can not buy

			currentActiondialogType = actionDialogType.AdType;
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
			dialog.SetDialogDelegate(this);
			dialog.SetTitle("Not enough Point ! ");
			dialog.SetMessage(rewardAdMessage);

			Debug.Log("U>> Current action dialog in buy button - " + currentActiondialogType);
			//if (RewardAdController.instance.IsRewardAdLoaded() == true)
			//         {
			//	currentActiondialogType = actionDialogType.AdType;
			//	IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
			//	dialog.SetTitle("Not enough Point ! ");
			//	dialog.SetMessage(rewardAdMessage);
			//}else
			//         {
			//	IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ErrorDialog);
			//	dialog.SetTitle("Not enough Point ! ");
			//	dialog.SetMessage("You have not enough point for purchage this item !");
			//}

		}
    }
	public void UseButtonClicked(StoreItemModel data)
	{
		_currentStoreItem = data;
		GameDataHandler.instance.SetCurrentPlayer(data.itemType);
		storeListItemHandler.Setup();
		Debug.Log("U>> Current action dialog in Use button - " + currentActiondialogType);
	}

	public void CrossButtonClicked()
	{
		HidePanelObj();
		GameActionHandler.instance.BackButtonPressed();
	}

	public void OnDialogPositiveButtonPressed()
	{
		Debug.Log("U>> Current action dialog on positive btn - - " + currentActiondialogType);
		if (currentActiondialogType == actionDialogType.PurchaseType)
		{
			//if (_currentStoreItem == null)
			//	return;

			if (PurchaseItem(_currentStoreItem) == true)
			{
				IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
				dialog.SetTitle("Purchase Confirmation");
				dialog.SetMessage(" Congratulations !  .\n  You Successfully Purchased the item.");
				storeListItemHandler.Setup();
			}
		}
		Debug.Log("U>> Current action dialog " + currentActiondialogType);
		if (currentActiondialogType == actionDialogType.AdType)
		{
			ShowRewardAdButtonClicked();
		}

	}

	public void ShowRewardAdButtonClicked()
	{
		SmileSoftAdManager.instance.ShowRewardAd((receivedRewardType, receivedRewardAmount, isSuccess) => {

			if (isSuccess)
            {
				PlayerAchivedDataHandler.instance.SetTotalScore(PlayerAchivedDataHandler.instance.GetTotalScore() + (int)receivedRewardAmount);

				IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
				dialog.SetTitle("Success!");
				dialog.SetMessage("You Get " + (int)receivedRewardAmount + " point. \n your current point is " + PlayerAchivedDataHandler.instance.GetTotalScore());
			}
		});
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

	
 //   private void ShowRewardAdDialog()
 //   {
	//	currentActiondialogType = actionDialogType.AdType;

 //       IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
	//	dialog.SetDialogDelegate(this);
	//	dialog.SetTitle("Get Point!");
	//	dialog.SetMessage(rewardAdMessage);
	//}

 //   private void OnChangeRewardAdLoadedStatus(bool isLoaded)
 //   {
	//	_isRewardAdLoaded = isLoaded;
	//  //  _adButton.interactable = _isRewardAdLoaded;
	//}
}
