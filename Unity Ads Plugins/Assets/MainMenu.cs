using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{




    void Start()
    {
        AdsTest.Instance.InitGoogleAdsSDK();
        AdsTest.Instance.InitFacebookInterstitial();
        AdsTest.Instance.InitUnityAds();


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
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
    public void InitAdmobRewardIntAd()
    {
        AdsTest.Instance.InitAdmobRewardedInterstitialAd();
    }
    public void ShowAdmobRewardIntAd()
    {
        AdsTest.Instance.ShowRewardedInterstitialAd();
    }
}
