using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{




    void Start()
    {
        AdsTest.Instance.InitGoogleAdsSDK();
        AdsTest.Instance.InitFacebookInterstitial();


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
}
