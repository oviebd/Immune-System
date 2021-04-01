using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class YodoBannerAd : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		Yodo1U3dMas.SetBannerAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
			Debug.Log("[Yodo1 Mas] BannerdDelegate:" + adEvent.ToString() + "\n" + error.ToString());
			switch (adEvent)
			{
				case Yodo1U3dAdEvent.AdClosed:
					Debug.Log("[Yodo1 Mas] Banner ad has been closed.");
					break;
				case Yodo1U3dAdEvent.AdOpened:
					Debug.Log("[Yodo1 Mas] Banner ad has been shown.");
					break;
				case Yodo1U3dAdEvent.AdError:
					Debug.Log("[Yodo1 Mas] Banner ad error, " + error.ToString());
					break;
			}
		});

		ShowBannedAd();
	}

	public void ShowBannedAd()
	{
		int align = Yodo1U3dBannerAlign.BannerBottom;
		int offsetX = 10;
		int offsetY = 10;
		Yodo1U3dMas.ShowBannerAd(align, offsetX, offsetY);
	}

    public void CloseBannerAd()
	{
		Yodo1U3dMas.DismissBannerAd();
	}
}
