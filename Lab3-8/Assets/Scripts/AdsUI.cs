using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdsUI : MonoBehaviour
{

    public AdsManager unityAdsManager;
    public Button initBtn;
    public Button loadRewardedBtn;
    public Button showRewardedBtn;
    public Button loadInterstitialBtn;
    public Button showInterstitialBtn;
    public Button toggleBannerBtn;

    public Text debugLogText;

    private string textLog = "DEBUG LOG: \n";

    private void Awake()
    {
        //if you didn't assign in the inspector
        if (unityAdsManager == null)
        {
            unityAdsManager = FindObjectOfType<AdsManager>();
        }
    }

    private void Start()
    {
        initBtn.onClick.AddListener(unityAdsManager.Initialize);
        initBtn.onClick.AddListener(()=> debugLogText.text = "DEBUG LOG: \n");

        loadRewardedBtn.onClick.AddListener(unityAdsManager.LoadRewardedAd);
        showRewardedBtn.onClick.AddListener(unityAdsManager.ShowRewardedAd);

        loadInterstitialBtn.onClick.AddListener(unityAdsManager.LoadNonRewardedAd);
        showInterstitialBtn.onClick.AddListener(unityAdsManager.ShowNonRewardedAd);

        toggleBannerBtn.onClick.AddListener(unityAdsManager.ToggleBanner);
    }

    private void OnEnable()
    {
        AdsManager.OnDebugLog += HandleDebugLog;
    }

    private void OnDisable()
    {
        AdsManager.OnDebugLog -= HandleDebugLog;
    }


    void HandleDebugLog(string msg)
    {
        textLog += "\n" + msg + "\n";
        debugLogText.text = textLog;
    }
}
