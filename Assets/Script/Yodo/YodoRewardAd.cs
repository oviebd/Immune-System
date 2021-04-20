using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class YodoRewardAd : MonoBehaviour
{
	public static YodoRewardAd instance;

	[Header("how much point you get after watch a reward ad")]
	[SerializeField] private int rewardPoint = 30;

	public delegate void RewardAdLoaded(bool isLoaded);
	public static event RewardAdLoaded onRewardAdLoaded;
	

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public int GetRewardPoint()
	{
		return rewardPoint;
	}

	void Start()
    {
		Yodo1U3dMas.SetRewardedAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
			Debug.Log("[Yodo1 Mas] RewardVideoDelegate:" + adEvent.ToString() + "\n" + error.ToString());
			switch (adEvent)
			{
				case Yodo1U3dAdEvent.AdClosed:
					Debug.Log("[Yodo1 Mas] Reward video ad has been closed.");
					break;
				case Yodo1U3dAdEvent.AdOpened:
					Debug.Log("[Yodo1 Mas] Reward video ad has shown successful.");
					break;
				case Yodo1U3dAdEvent.AdError:
					Debug.Log("[Yodo1 Mas] Reward video ad error, " + error);
					break;
				case Yodo1U3dAdEvent.AdReward:
					Debug.Log("[Yodo1 Mas] Reward video ad reward, give rewards to the player.");

					break;
			}

		});
	}

   public void ShowAd()
	{

		if (Utils.isNetworkAvilable() == false && Yodo1U3dMas.IsRewardedAdLoaded() == false)
		{
			IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ErrorDialog);
			dialog.SetTitle("No Internet!");
			dialog.SetMessage("Please check your Network connection..");
		}
		else
		{
			Yodo1U3dMas.ShowRewardedAd();
		/*	if ( Yodo1U3dMas.IsRewardedAdLoaded())
			{
				Yodo1U3dMas.ShowRewardedAd();
			}
			else
			{
				IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ErrorDialog);
				dialog.SetTitle("Sorry!");
				dialog.SetMessage("Can not show ad right now \n Please try again later");
			}*/
		}

	//	bool isLoaded = Yodo1U3dMas.IsRewardedAdLoaded();
		
	}

	private void GiveReward()
	{
		PlayerAchivedDataHandler.instance.SetTotalScore(PlayerAchivedDataHandler.instance.GetTotalScore() + GetRewardPoint());

		IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
		dialog.SetTitle("Success!");
		dialog.SetMessage("You Get " + GetRewardPoint() + " point. \n your current point is " + PlayerAchivedDataHandler.instance.GetTotalScore());
	}
}
