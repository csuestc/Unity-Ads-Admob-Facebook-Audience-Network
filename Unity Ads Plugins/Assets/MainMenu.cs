﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{




    void Start()
    {
        AdsTest.Instance.InitGoogleAdsSDK();
        AdsTest.Instance.InitFacebookInterstitial();
        AdsTest.Instance.InitUnityAds();


    }


    public void ShowAdmobInt()
    {
        AdsTest.Instance.ShowAdmobInterstitialAd();
    }
    public void ShowFBInt()
    {
        AdsTest.Instance.ShowInterstitialFacebook();
    }
    public void ShowBanner()
    {
        AdsTest.Instance.ShowBanner();
    }
    public void HideBanner()
    {
        AdsTest.Instance.HideBannerAd();
    }

    public void ShowUnityAds()
    {
        AdsTest.Instance.ShowUnityAds();
    }

    public void ShowAdmobRewardAd()
    {
        AdsTest.Instance.ShowAdmobReward();
    }

    public void ShowAdmobRewardIntAd()
    {
        AdsTest.Instance.ShowRewardedInterstitialAd();
    }
}
