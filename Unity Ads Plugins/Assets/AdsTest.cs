using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;

public class AdsTest : MonoBehaviour
{
    GoogleMobileAds.Api.InterstitialAd interstitial;

    [SerializeField] string AdmobBannerId = "ca-app-pub-3940256099942544/6300978111";

    [SerializeField] string AdmobIntertestialID = "ca-app-pub-3940256099942544/1033173712";

    [SerializeField] private string FacebookInterstitialID = "116719410120917_116719460120912";



    private AudienceNetwork.InterstitialAd interstitialAd;
    private bool isLoaded;



    string AdmobAppID = "ca-app-pub-3940256099942544~3347511713";

    string UntiyAdId = "3774033";







    const string RewardedPlacementId = "rewardedVideo";

    private static AdsTest _instance = null;

    public static AdsTest Instance { get { return _instance; } }

    BannerView bannerView;

    AdRequest request;

    //Refrence to this class using property
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<AdsTest>() as AdsTest;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }




    public void InitGoogleAdsSDK()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            MobileAds.Initialize(initStatus =>
            {
                InitBannerAds();
                ShowBanner();
                InitInterstitial();
            });
        }
    }

    public void InitFacebookInterstitial()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            this.interstitialAd = new AudienceNetwork.InterstitialAd(FacebookInterstitialID);
            this.interstitialAd.Register(this.gameObject);
        }

    }



    public void LoadInterstitialFacebook()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // Set delegates to get notified on changes or when the user interacts with the ad.
            this.interstitialAd.InterstitialAdDidLoad = (delegate ()
            {
                //Debug.Log("Interstitial ad loaded.");

                this.isLoaded = true;
            });
            interstitialAd.InterstitialAdDidFailWithError = (delegate (string error)
            {
                //Debug.Log("Interstitial ad failed to load with error: " + error);

            });
            interstitialAd.InterstitialAdWillLogImpression = (delegate ()
            {
                //Debug.Log("Interstitial ad logged impression.");

            });
            interstitialAd.InterstitialAdDidClick = (delegate ()
            {
                //Debug.Log("Interstitial ad clicked.");

            });

            this.interstitialAd.interstitialAdDidClose = (delegate ()
            {


                if (this.interstitialAd != null)
                {
                    this.interstitialAd.Dispose();
                }
            });

            this.interstitialAd.LoadAd();

        }
    }

    public void ShowInterstitialFacebook()
    {


        if (this.isLoaded)
        {
            //this.interstitialAd.Show();
            this.isLoaded = false;
        }

    }



    public void ToggleAdsCall()
    {
        if (PlayerPrefs.GetInt("Adtogle", 0) == 0)
        {
            ShowInterstitialFacebook();
            PlayerPrefs.SetInt("Adtogle", 1);

        }
        else
        {
            Show_Admob_InterstitialAd();
            PlayerPrefs.SetInt("Adtogle", 0);
        }
    }




    public void InitBannerAds()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            this.RequestBanner();
        }
    }


    private void RequestBanner()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            bannerView = new BannerView(AdmobBannerId, AdSize.Banner, AdPosition.TopLeft);

            request = new AdRequest.Builder().Build();

            bannerView.LoadAd(request);
        }

    }

    //Admob Banner Request
    public void ShowBanner()
    {

        //show banner view
        if (Application.platform == RuntimePlatform.Android)
        {
            bannerView.Show();
        }
    }

    public void HideBannerAd()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            bannerView.Hide();
        }
    }

    public void InitInterstitial()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            this.interstitial = new GoogleMobileAds.Api.InterstitialAd(AdmobIntertestialID);

            this.interstitial.OnAdClosed += HandleOnAdClosed;
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);

            // Advertising.LoadInterstitialAd();

        }

    }

    public void Show_Admob_InterstitialAd()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }

        }

    }



    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //this.interstitial.OnAdClosed -= HandleOnAdClosed;
        InitInterstitial();
    }



}
