using UnityEngine;
using System.Collections;
using System;
using GoogleMobileAds.Api;

public class GoogleAdmobView : MonoBehaviour {

    private BannerView bannerView;
    private InterstitialAd interstitial;

    public static GoogleAdmobView Instance;
    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        RequestBanner();
        RequestInterstitial();
    }

    public void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "/112517806/16281513330531";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        
        string adUnitId = "/112517806/36281513330531";
        
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Clean up banner ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        bannerView.Show();
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        RequestBanner();
        RequestInterstitial();
    }
    
    public void ShowInterstitialAds()
    {
        //StartCoroutine(ShowIntAds());
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            RequestInterstitial();
        }
    }

    //IEnumerator ShowIntAds()
    //{
    //string adUnitId = "ca-app-pub-2050458746961158/9325708415";
    //string adUnitId = "ca-app-pub-2050458746961158/9079910800";
    //    yield return new WaitForSeconds(1f);
    //    if (interstitial.IsLoaded())
    //    {
    //        interstitial.Show();
    //    }
    //    else
    //    {
    //        RequestInterstitial();
    //    }
    //}

    public void OnDisableBaner()
    {
        bannerView.Destroy();        
    }
    public void OnDisableInterstitial()
    {
        interstitial.Destroy();
    }
}
