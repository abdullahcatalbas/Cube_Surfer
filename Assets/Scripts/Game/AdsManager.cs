using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using HuaweiMobileServices.Ads;
using HmsPlugin;
using UnityEngine.UI;



public class AdsManager : MonoBehaviour
{
    
    public static AdsManager instance;
    public ScoreManager sc;
    public bool HideAds = false;
    public bool Double = false;
    public bool rewarded;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        HMSAdsKitManager.Instance.OnRewardAdCompleted = OnRewardAdCompleted;
        HMSAdsKitManager.Instance.OnRewardAdClosed = OnRewardAdClosed;
    }

    public void ShowBannerAd()
    
    {
        if(HideAds) return;
        HMSAdsKitManager.Instance.ShowBannerAd();
    }

    public void HideBannerAd()
    {

        HMSAdsKitManager.Instance.HideBannerAd();
    }


    public void OnRewarded(Reward reward){
        Debug.Log("[HMS] AdsManager rewarded!");
        sc.AddGems();
    
    }

    public void ShowRewardedAd()
    {
        Debug.Log("[HMS] AdsManager ShowRewardedAd");
        HMSAdsKitManager.Instance.OnRewarded = OnRewarded;
        HMSAdsKitManager.Instance.ShowRewardedAd();


    }
    private void OnRewardAdClosed()
    {
        Debug.Log("OnRewardAdClosed");
        if(rewarded){
        Debug.Log("Rewarding user");
        
        rewarded = false;
        }
         
        
    }

    private void OnRewardAdCompleted()
    {
        Debug.Log("OnRewardAdCompleted");
        

    }
    

    public void ShowInterstitialAd()
    {
        if(HideAds) return;
        Debug.Log("[HMS] AdsManager ShowInterstitialAd");
        HMSAdsKitManager.Instance.ShowInterstitialAd();
    }


    public void OnInterstitialAdClosed()
    {
        Debug.Log("[HMS] AdsManager interstitial ad closed");
    }

    public void SetTestAdStatus()
    {
        HMSAdsKitManager.Instance.DestroyBannerAd();
        HMSAdsKitManager.Instance.LoadAllAds();
    }
}
