using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_ANDROID
    string gameID = "4422557";
#endif

    public PlayerPrefsLogic playerPrefsLogic;
    public PlayerLives playerLivesLogic;
    public GameLogic gameLogic;
    public StartScreenLogic startScreenLogic;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID);
        playerPrefsLogic = FindObjectOfType<PlayerPrefsLogic>();
        gameLogic = FindObjectOfType<GameLogic>();
        startScreenLogic = FindObjectOfType<StartScreenLogic>();
        Advertisement.AddListener(this);
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {

            Advertisement.Show("Interstitial_Android");
        }

    }

    public void PlayRewaredeAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else 
        {
            Debug.Log("AD NOT READY!");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad Ready :)");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ad Error : "+ message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {

        adFinishedGameLogic(placementId, showResult);
        adFinishedStartScreenLogic(placementId,showResult);

    }

    void adFinishedGameLogic(string placementId, ShowResult showResult)
    {
        if (gameLogic != null)
        {

            if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
            {
                playerPrefsLogic.PlayedRewardedAdJustNow();
            }
            if (placementId == "Interstitial_Android" && showResult == ShowResult.Finished)
            {
                playerLivesLogic.SetMaxLives();
                gameLogic.RestartGame();
            }
        }
    }
    void adFinishedStartScreenLogic(string placementId, ShowResult showResult)
    {
        if (startScreenLogic != null)
        {

            if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
            {
                playerPrefsLogic.PlayedRewardedAdJustNow();
                playerLivesLogic.SetMaxLives();
                startScreenLogic.StartGame();
            }
            if (placementId == "Interstitial_Android" && showResult == ShowResult.Finished)
            {
                playerLivesLogic.SetMaxLives();
                startScreenLogic.StartGame();
            }
        }
    }
}
