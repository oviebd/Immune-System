using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] private bool _isPublish = false;
    [SerializeField] private int _gameOverStateNumberForInterstitialAd = 2;
    private int _currentGameOverStateNumber = 0;

    private BannerView bannerView;
    private RewardedAd rewardBasedVideo;
    private InterstitialAd interstitial;

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
   
    public void Start()
    {
        string appId = AdUtility.GetAppId();

        MobileAds.Initialize(appId);

        RequestBanner();
        RequestInterstitial();
        RewardAdController.instance.SetupAd();

    }

    public bool GetAppPublishMode()
    {
        return _isPublish;
    }

    #region Banner Ad

    public void RequestBanner()
    {
        string adUnitId = AdUtility.GetBannerAdId(_isPublish);
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    private void DestroyBanner()
    {
        if (bannerView != null)
            bannerView.Destroy();
    }
    private void HideBannerAD()
    {
        if (bannerView != null)
            bannerView.Hide();
    }
    private void ShowBannerAD()
    {
        if(bannerView != null)
            bannerView.Show();
    }

    #endregion Banner Ad

    #region Interstitial Ad

    private void RequestInterstitial()
    {
        string adUnitId = AdUtility.GetInterstitialAdId(_isPublish);
      
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void ShowInerstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    #endregion Interstitial Ad


    public void ShowRewardAd()
    {
        RewardAdController.instance.ShowRewardAd();
    }


    private void OnGameStateChange(GameEnum.GameState state)
    {
        if(state == GameEnum.GameState.PlayerLose || state == GameEnum.GameState.PlayerWin)
        {
            Debug.Log(_currentGameOverStateNumber % _gameOverStateNumberForInterstitialAd);
            if( (_currentGameOverStateNumber % _gameOverStateNumberForInterstitialAd) == 0)
            {
                ShowInerstitialAd();
            }
            _currentGameOverStateNumber = _currentGameOverStateNumber + 1;
        }
        if (state == GameEnum.GameState.Running)
            HideBannerAD();
        else
            ShowBannerAD();

    }
}
