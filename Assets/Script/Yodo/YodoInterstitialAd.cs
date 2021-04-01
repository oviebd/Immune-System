using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class YodoInterstitialAd : MonoBehaviour
{
    
    void Start()
    {
		Yodo1U3dMas.SetInterstitialAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
			Debug.Log("[Yodo1 Mas] InterstitialAdDelegate:" + adEvent.ToString() + "\n" + error.ToString());
			switch (adEvent)
			{
				case Yodo1U3dAdEvent.AdClosed:
					Debug.Log("[Yodo1 Mas] Interstital ad has been closed.");
					break;
				case Yodo1U3dAdEvent.AdOpened:
					Debug.Log("[Yodo1 Mas] Interstital ad has been shown.");
					break;
				case Yodo1U3dAdEvent.AdError:
					Debug.Log("[Yodo1 Mas] Interstital ad error, " + error.ToString());
					break;
			}
		});
	}

	public void ShowAd()
	{
		bool isLoaded = Yodo1U3dMas.IsInterstitialAdLoaded();
		Yodo1U3dMas.ShowInterstitialAd();
	}

  
}
