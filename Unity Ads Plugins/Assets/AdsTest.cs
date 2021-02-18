using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;

public class AdsTest : MonoBehaviour
{
    private static AdsTest _instance = null;
    public static AdsTest Instance { get { return _instance; } }

    GoogleMobileAds.Api.InterstitialAd interstitialAdmob;
    BannerView bannerView;
    AdRequest request;

    AudienceNetwork.InterstitialAd interstitialFacebook;

    [SerializeField] string AdmobBannerID = "ca-app-pub-3940256099942544/6300978111";
    [SerializeField] string AdmobIntertestialID = "ca-app-pub-3940256099942544/1033173712";
    string AdmobAppID = "ca-app-pub-3940256099942544~3347511713"; //for reference 

    [SerializeField] string FacebookInterstitialID = "YOUR_PLACEMENT_ID";
    [SerializeField] string UntiyAdID = "Your_UnityAds";



    private bool isLoaded;




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
                InitAdmobInterstitial();
            });
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

            bannerView = new BannerView(AdmobBannerID, AdSize.Banner, AdPosition.TopLeft);

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

    public void InitAdmobInterstitial()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            this.interstitialAdmob = new GoogleMobileAds.Api.InterstitialAd(AdmobIntertestialID);

            this.interstitialAdmob.OnAdClosed += HandleOnAdClosed;
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitialAdmob.LoadAd(request);

            // Advertising.LoadInterstitialAd();

        }

    }

    public void ShowAdmobInterstitialAd()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (this.interstitialAdmob.IsLoaded())
            {
                this.interstitialAdmob.Show();
            }

        }

    }



    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //this.interstitial.OnAdClosed -= HandleOnAdClosed;
        InitAdmobInterstitial();
    }

    public void InitFacebookInterstitial()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            this.interstitialFacebook = new AudienceNetwork.InterstitialAd(FacebookInterstitialID);
            this.interstitialFacebook.Register(this.gameObject);
            LoadInterstitialFacebook();
        }

    }



    public void LoadInterstitialFacebook()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // Set delegates to get notified on changes or when the user interacts with the ad.
            this.interstitialFacebook.InterstitialAdDidLoad = (delegate ()
            {
                //Debug.Log("Interstitial ad loaded.");

                this.isLoaded = true;
            });
            interstitialFacebook.InterstitialAdDidFailWithError = (delegate (string error)
            {
                //Debug.Log("Interstitial ad failed to load with error: " + error);

            });
            interstitialFacebook.InterstitialAdWillLogImpression = (delegate ()
            {
                //Debug.Log("Interstitial ad logged impression.");

            });
            interstitialFacebook.InterstitialAdDidClick = (delegate ()
            {
                //Debug.Log("Interstitial ad clicked.");

            });

            this.interstitialFacebook.interstitialAdDidClose = (delegate ()
            {


                if (this.interstitialFacebook != null)
                {
                    this.interstitialFacebook.Dispose();
                }
            });

            this.interstitialFacebook.LoadAd();

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







}
