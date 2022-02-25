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

    public PGS_Manager playGames_Manager;
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
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ad Error : "+ message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
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
                playGames_Manager.UnlockAchievement(playGames_Manager.thankYou_Acheive);
                
            }
            if (placementId == "Interstitial_Android")
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
                playGames_Manager.UnlockAchievement(playGames_Manager.thankYou_Acheive);
                playerPrefsLogic.PlayedRewardedAdJustNow();
                playerLivesLogic.SetMaxLives();
                startScreenLogic.SetRewardBttnNoOpt();
                //set max lives and start game
                startScreenLogic.StartGame();
            }
            if (placementId == "Interstitial_Android")
            {
                playerLivesLogic.SetMaxLives();
                startScreenLogic.StartGame();
            }
        }
    }
}
