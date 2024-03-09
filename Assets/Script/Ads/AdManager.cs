using System;
using GoogleMobileAds.Api;
using UnityEngine;
using SmileSoft_Ads_Manager;

public class AdManager : MonoBehaviour
{
    //[Header("Made it true for release build. If this is true then it will show real ads not test ads")]
    //[SerializeField] private bool _isPublish = false;
    [Header("How many gameOver state needs for showing a single interstitial ad")]
    [SerializeField] private int _gameOverStateNumberForInterstitialAd = 2;
    private int _currentGameOverStateNumber = 0;


    public static AdManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        GameManager.onGameStateChange += OnGameStateChange;
        _currentGameOverStateNumber = 0;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChange -= OnGameStateChange;
    }
  

    //public bool GetAppPublishMode()
    //{
    //    return _isPublish;
    //}

   
   
    private void HideBannerAD()
    {
        SmileSoftAdManager.instance.HideBannerAd();
    }
    private void ShowBannerAD()
    {

        SmileSoftAdManager.instance.ShowBannerAd(AdSize.Banner, AdPosition.Bottom);
    }


    public void ShowRewardAd()
    {
        SmileSoftAdManager.instance.ShowRewardAd((receivedRewardType, receivedRewardAmount, isSuccess) => { } );
    }

    public void ShowInterstitialAd()
    {
       SmileSoftAdManager.instance.ShowInterstitialAd(isSuccess => { } );
    }


    private void OnGameStateChange(GameEnum.GameState state)
    {
        if(state == GameEnum.GameState.PlayerLose || state == GameEnum.GameState.PlayerWin)
        {
            if( (_currentGameOverStateNumber % _gameOverStateNumberForInterstitialAd) == 0)
            {
                ShowInterstitialAd();
            }
            _currentGameOverStateNumber = _currentGameOverStateNumber + 1;
        }

        if (state == GameEnum.GameState.Running)
            HideBannerAD();
        else
            ShowBannerAD();
    }
}
