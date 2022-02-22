using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;


public class PGS_Manager : MonoBehaviour
{
    public static PlayGamesPlatform platform;
    public HighscorePopup highscorePopup;
    public PlayerPrefsLogic playerPrefsLogic;
    public Canvas startMenu;
    public Button signin;
    public Text signinText;
    public Button showLeaderboards;

    private IScore leaderboardScore = null;
    private string leaderboardID = "CgkIr6rUlLIVEAIQCw";

    void Start()
    {

        signin.onClick.AddListener(() => SignIn());
        showLeaderboards.onClick.AddListener(() => ShowLeaderboard());

        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
        }
        // Select the Google Play Games platform as our social platform implementation
        SilentLogin();
    }

    void SilentLogin()
    {
        if (!Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
            {
                if(result == SignInStatus.Success)
                {
                    //Logged in.
                    Debug.Log("User ID: " + platform.GetUserId());
                    Debug.Log("User Display Name: " + platform.GetUserDisplayName());
                    Debug.Log("All User: " + platform.localUser.ToString());
                    Debug.Log("SocialUser : " + Social.localUser.ToString());

                    getLeaderboardscore();
                    postLeaderboardscore(playerPrefsLogic.GetHighschorePref());

                    if (startMenu != null)
                        startMenu.enabled = true;
                    SetSignedInUI();
                }
                else{
                    Debug.Log("**Authentication failed.**");
                    if (startMenu != null)
                        startMenu.enabled = true;
                    SetSignedOutUI();
                }
            });
        }
        else
        {
            if(startMenu!=null)
                startMenu.enabled = true;
            SetSignedInUI();
        }


    }
    
    public void ShowLeaderboard()
    {
        if(Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }
    
    public void SignIn()
    {
        // Authenticate
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (result) =>
        {
            if (result == SignInStatus.Success)
            {
                postLeaderboardscore(playerPrefsLogic.GetHighschorePref());
                ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.BOTTOM);
                if(startMenu != null)
                    startMenu.enabled = true;
                SetSignedInUI();

            }
            else
            {
                Debug.Log("**Authentication failed.**");
                if (startMenu != null)
                    startMenu.enabled = true;
                SetSignedOutUI();

            }
        });
    }

    public void SignOut()
    {
        if(Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.SignOut();
        }
        SetSignedOutUI();

    }

    private void SetSignedOutUI()
    {
        signin.onClick.AddListener(() => SignIn());
        signinText.text = "Sign In";
        signin.enabled = true;
        showLeaderboards.enabled = false;
        
    }
    private void SetSignedInUI()
    {
        signin.onClick.AddListener(() => SignOut());
        signinText.text = "Sign Out";
        signin.enabled = true;
        showLeaderboards.enabled = true;
    }

    public void postLeaderboardscore(int newScore)
    {
        if(Social.localUser.authenticated){
            Social.ReportScore(newScore, leaderboardID, (bool success) =>
            {
                if(success)
                {
                    //UI Pop up
                    Debug.Log("Posted Score: "+ newScore);
                    Social.LoadScores(leaderboardID, scores => {
                        if(scores.Length >0)
                        {
                            foreach (IScore score in scores)
                            {
                                if(score.userID == Social.localUser.id)
                                {
                                    leaderboardScore = score;
                                    highscorePopup.ResetBox();
                                    highscorePopup.PopUp(score.rank);

                                }
                            }
                        }
                    });
                }
                else
                {
                    Debug.Log("Post Score Failed");
                }
            });
        }
        
    }

    public void getLeaderboardscore()
    {
        int retValue = 0;
        if(Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.LoadScores(leaderboardID, scores => {
                if(scores.Length > 0)
                {
                    foreach (IScore score in scores)
                    {
                        
                        if(score.userID == Social.localUser.id)
                        {
                            leaderboardScore = score;
                            Debug.Log("Score User: "+score.userID +"\tScore Value: "+ score.value+"\tScore Formatted: "+ score.formattedValue);
                            retValue = int.Parse(score.formattedValue);
                            playerPrefsLogic.SetHighscorePref(retValue);
                        }
                    }
                }

            });
        }
    }

}
