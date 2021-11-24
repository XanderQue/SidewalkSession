using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrefsLogic : MonoBehaviour
{

    public GameLogic gameLogic;
    public StartScreenLogic startScreenLogic;
    public PlayerLives playerLivesLogic;

    public static string GO_Time_Hr_Pref = "GO_Time_Hr";
    public static string GO_Time_Min_Pref ="GO_Time_MIN";
    public static string GO_Time_Year_Pref ="GO_Time_Year";
    public static string GO_Time_DayOfYear_Pref = "GO_Time_DayOfYear";
    public static string GO_Timeout_Time_Pref = "GO_Timeout_Time";

    public static string Player_HighScore_Pref = "player_highscore";

    public static string Player_Lives_Pref = "Player_Lives";

    public static string RA_Time_Hr_Pref = "RA_Time_Hr";
    public static string RA_Time_Min_Pref = "RA_Time_MIN";
    public static string RA_Time_Year_Pref = "RA_Time_Year";
    public static string RA_Time_DayOfYear_Pref = "RA_Time_DayOfYear";

    bool rewardActive = false;
    bool hasLives = false;

    bool hasGO_Time_Prefs = false;
    bool hasRA_Time_Prefs = false;


    int startingLives = 3;
    int playerLives = 0;

    int gameOverTimeHour = 0;
    int gameOverTimeMin = 0;
    int gameOverDayOfYear = 0; // out of 365/366
    int gameOverYear = 0;

    int rewardedAdTimeHour = 0;
    int rewardedAdTimeMin = 0;
    int rewardedAdDayOfYear = 0; // out of 365
    int rewardedAdYear = 0;

    System.DateTime rewardedAdTime;
    System.DateTime timeNow;


    int gameOverTimeOut = 1; // in Hrs

    string currentGO_Timeout_Time = "00:00 am";
    int currentGO_Time_State = 0;
    //Return Values
    /*
     * 0 - new player
     * 1 - reward active
     * 2 - has lives
     * 3 - Game Over no lives
     */

    // Start is called before the first frame update
    void Start()
    {

        //Get from playerprefs
        //GetPlayerPrefs();
        gameLogic = FindObjectOfType<GameLogic>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {

        if (CheckRewardActive() && startScreenLogic != null)
        {
            GetTimeNow();
            Debug.Log("Has reward start screen not null");
            //fixed update time
            int minLeft = 0;
            if (timeNow.Hour == rewardedAdTimeHour)
            {
                Debug.Log("Time hr == RA hour");

                minLeft = 60 - (timeNow.Minute - rewardedAdTimeMin);
            }
            else if (timeNow.Hour == rewardedAdTimeHour + 1 || rewardedAdTimeHour == 23)
            {
                Debug.Log("Time hr == RA hour +1");
                minLeft = rewardedAdTimeMin - timeNow.Minute;
                Debug.Log("Min Left == " + minLeft);
            }
            startScreenLogic.rewardTimeText.text = minLeft.ToString() + startScreenLogic.rewardTimeString;
        }
        else if (CheckRewardActive() && gameLogic != null)
        {
            GetTimeNow();
            Debug.Log("Has reward game logic not null");
            //fixed update time
            int minLeft = 0;
            if (timeNow.Hour == rewardedAdTimeHour)
            {
                Debug.Log("Time hr == RA hour");

                minLeft = 60 - (timeNow.Minute - rewardedAdTimeMin);
            }
            else if (timeNow.Hour == rewardedAdTimeHour + 1 || rewardedAdTimeHour == 23)
            {
                Debug.Log("Time hr == RA hour +1");
                minLeft = rewardedAdTimeMin - timeNow.Minute;
                Debug.Log("Min Left == " + minLeft);
            }
            gameLogic.rewardActiveText.text = minLeft.ToString() + gameLogic.rewaredTimerString;
        }
    }
    //Return Values
    /*
     * -1 - Error
     * 0 - new player
     * 1 - reward active
     * 2 - has lives
     * 3 - Game Over no lives
     */

    void gameOverPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("FirstTime"))
        {
            Debug.Log("This aint your FirstTime in gameOverPlayerPrefs()");
            //get lives
            playerLives = playerLivesLogic.GetLives();

            if (playerLives <= 0)
            {

                Debug.Log("PlayerPrefsLogic.gameOverPlayerPrefs() Player lives <= O");
                //not first time and no lives 
                //Do you have coins?
                if ((hasRA_Time_Prefs = GetRewardAdTimePrefs()))//if reward ad time
                {
                    Debug.Log("has RA Time Prefs");
                    if (CheckRewardActive())
                    {
                        Debug.Log("Reward active");
                        //Player can Play ************** 
                        playerLives = playerLivesLogic.SetLives(startingLives);
                        currentGO_Time_State = 1;

                        if (gameLogic != null)
                        {
                            Debug.Log("Game Logic");
                            gameLogic.SetContinueBttnNoAd();
                            gameLogic.SetRewardBttnNoOpt();
                        }

                        return;
                    }
                    else
                    {
                        Debug.Log("Reward not active");
                        if (gameLogic != null)
                        {
                            Debug.Log("Game Logic");
                            gameLogic.SetRewardBttnWatchAd();
                        }
                    }
                }
                else 
                {
                    Debug.Log("Reward not active");
                    if (gameLogic != null)
                    {
                        Debug.Log("Game Logic");
                        gameLogic.SetRewardBttnWatchAd();
                    }
                }

                if (hasGO_Time_Prefs = GetGameOverTimePrefs())
                {
                    Debug.Log("Has GO Time Prefs");
                    //if game over time then.
                    //Cant play until game over time +24hrs

                    SetGameOverTimeText();

                    if (CheckGameOverCycle())
                    {
                        //Game over cycle ended
                        currentGO_Time_State = 2;
                        playerLives = playerLivesLogic.SetLives(startingLives);
                        if (gameLogic != null)
                        {
                            Debug.Log("Game Logic- set continue no ad");
                        gameLogic.SetContinueBttnNoAd();
                    }

                        return;
                    }
                    else
                    {
                        if (gameLogic != null)
                        {
                            Debug.Log("Game Logic- set continue with ad");
                           gameLogic.SetContinueBttnWatchAd();
                        }
                        currentGO_Time_State = 3;
                        return;
                    }
                }
                if (gameLogic != null)
                {
                    Debug.Log("Game Logic- set continue with ad");
                    gameLogic.SetContinueBttnWatchAd();
                }
                currentGO_Time_State = 3;
                return;




            }
            //has lives
            else
            {
                Debug.Log("Has Lives!");
                currentGO_Time_State = 2;
                if (gameLogic != null)
                {
                    gameLogic.SetContinueBttnNoAd();
                    if (CheckRewardActive())
                    {
                        Debug.Log("Reward Active");
                        gameLogic.SetRewardBttnNoOpt();
                    }
                    else
                    {
                        Debug.Log("Reward not Active");
                        gameLogic.SetRewardBttnWatchAd();
                    }
                }

                return;
            }




        }
        else
        {
            FirstRunSave();

        }
        return;
    }
    void startScreenPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("FirstTime"))
        {
            Debug.Log("Not my first rodeo in Start Screen Player Prefs");
            //get lives
            playerLives = playerLivesLogic.GetLives();

            if (playerLives <= 0)
            {
                Debug.Log("Player lives less than zero");
                //not first time and no lives 
                //Do you have coins?
                if ((hasRA_Time_Prefs = GetRewardAdTimePrefs()))//if reward ad time
                {
                    Debug.Log("Has RA time");
                    if (CheckRewardActive())
                    {
                        //Player can Play ************** 
                        playerLives = playerLivesLogic.SetLives(startingLives);
                        currentGO_Time_State = 1;

                        if (startScreenLogic != null)
                        {
                            startScreenLogic.SetContinueBttnNoAd();
                            startScreenLogic.SetRewardBttnNoOpt();
                        }

                        return;
                    }
                    else
                    {
                        Debug.Log("No RA Time");
                        if (startScreenLogic != null)
                            startScreenLogic.SetRewardBttnWatchAd();
                    }
                    Debug.Log("End of Has RA time");
                }

                if (hasGO_Time_Prefs = GetGameOverTimePrefs())
                {
                    Debug.Log("Has GO Time");
                    //if game over time then.
                    //Cant play until game over time +24hrs

                    SetGameOverTimeText();

                    if (CheckGameOverCycle())
                    {
                        Debug.Log("Game over cycle ended");
                        //Game over cycle ended
                        currentGO_Time_State = 2;
                        playerLives = playerLivesLogic.SetLives(startingLives);
                        if (startScreenLogic != null)
                            startScreenLogic.SetContinueBttnNoAd();

                        return;
                    }
                    else
                    {
                        Debug.Log("Still have to wait till " + GetGameOverTime());
                        if (startScreenLogic != null)
                            startScreenLogic.SetContinueBttnWatchAd();
                        currentGO_Time_State = 3;
                        return;
                    }
                }




            }
            //has lives
            else
            {
                Debug.Log("Has lives");
                currentGO_Time_State = 2;
                if (startScreenLogic != null)
                {
                    Debug.Log("Start Screen Logic");
                    startScreenLogic.SetContinueBttnNoAd();
                    if (CheckRewardActive())
                    {
                        Debug.Log("Has reward");
                        startScreenLogic.SetRewardBttnNoOpt();
                    }
                    else
                    {
                        Debug.Log("No reward");
                        startScreenLogic.SetRewardBttnWatchAd();
                    }
                }

                return;
            }




        }
        else
        {
            FirstRunSave();

        }
        return;
    }
    void FirstRunSave()
    {
        PlayerPrefs.SetInt("FirstTime", 0);
        PlayerPrefs.Save();


        startScreenLogic.SetContinueBttnNoAd();
        startScreenLogic.SetRewardBttnWatchAd();

        playerLives = playerLivesLogic.SetLives(startingLives);

        currentGO_Time_State = 0;
        return;
    }
    public void CheckLivesPlayerPrefs()
    {
        if (gameLogic != null)
        {
            Debug.Log("CheckLives Player Prefs - GameLogic");
            gameOverPlayerPrefs();

        }
        else if (startScreenLogic != null)
        {
            Debug.Log("CheckLives Player Prefs - StartScreenLogic");
            startScreenPlayerPrefs();
        }
        
    }

    //called by CheckLivesPlayerPrefs()
    void SetGameOverTimeText()
    {

        string hour = gameOverTimeHour.ToString();
        string min = gameOverTimeMin.ToString();

        string prefix = "AM";
        if (gameOverTimeMin < 10)
        {
            min = "0" + gameOverTimeMin.ToString();

        }
        if (gameOverTimeHour > 12)
        {
            if (gameOverTimeHour % 12 == 0)
            {
                hour = "12";
            }
            else
            {
                hour = (gameOverTimeHour - 12).ToString();
                prefix = "PM";
            }
        }
        currentGO_Timeout_Time = hour + ":" + min + " " + prefix;
    }
    public bool CheckRewardActive()
    {
        GetRewardAdTimePrefs();
        GetTimeNow();

        //check if reward ad is within one hour of watching
        //if its been over a year, its for sure not active
        if (rewardedAdYear == timeNow.Year)
        {
            //if same day

            /*
             * if hour is less than RA hour+1
             *      can play add lives
             * else if hour == RA time our+1
             *      if min <= RA min
             *          can play add lives
             
             */
            if (timeNow.DayOfYear == rewardedAdDayOfYear)
            {
                //then is now hour == reward hour+1
                if (timeNow.Hour < rewardedAdTimeHour + 1)
                {
                    return true;
                }
                else if(timeNow.Hour == rewardedAdTimeHour +1)
                { 
                    //if nowMin <= reward.min
                    if (timeNow.Minute <= rewardedAdTimeMin)
                    {
                        return true;
                    }
                }
            }

            //else if now.Day == reward day + 1    
            else if (timeNow.DayOfYear == rewardedAdDayOfYear + 1)
            {
                //if RA=23 && now=0
                if (timeNow.Hour == 0 && rewardedAdTimeHour == 23)
                {
                    //if nowMin <= reward.min
                    if (timeNow.Minute <= rewardedAdTimeMin)
                    {
                        return true;
                    }
                }
            }
        }
        else if (rewardedAdYear == timeNow.Year - 1)
        {
            if (timeNow.DayOfYear == 1 && (rewardedAdDayOfYear == 365 || rewardedAdDayOfYear == 366))
            {
                if (timeNow.Hour == 0 && rewardedAdTimeHour == 23)
                {
                    if (timeNow.Minute <= rewardedAdTimeMin)
                    {
                        return true;
                    }
                }
            }
        }
        return false; 

        
    }
    //Return Values
    /*
     * 0 - new player
     * 1 - reward active
     * 2 - has lives
     * 3 - Game Over no lives
     */
    public int GetLivesPref()
    {
        if (PlayerPrefs.HasKey(Player_Lives_Pref))
        {
            playerLives = PlayerPrefs.GetInt(Player_Lives_Pref);
            return playerLives;
        }
        else
            return -1;
    }
    public void SetLivesPref(int newLives)
    {
        Debug.Log("PlayerPrefsLogic.SetLivesPref( "+newLives+" )");
            
        playerLives = newLives;
        PlayerPrefs.SetInt(Player_Lives_Pref, playerLives);
        PlayerPrefs.Save();
       
    }
    public string GetGameOverTime()
    {
        if(PlayerPrefs.HasKey(GO_Timeout_Time_Pref))
        {
            currentGO_Timeout_Time = PlayerPrefs.GetString(GO_Timeout_Time_Pref);
        }
        
        return currentGO_Timeout_Time;
    }
    void SetGO_Timeout_TimePref(string newTime)
    {
        PlayerPrefs.SetString(GO_Timeout_Time_Pref, currentGO_Timeout_Time);
        PlayerPrefs.Save();

    }
    //Get from PlayerPrefs
    //returns false is key does not exist
    bool GetGameOverTimePrefs()
    {

        //Ensure the Key exists in PlayerPrefs
        if (PlayerPrefs.HasKey(GO_Time_Hr_Pref)
            && PlayerPrefs.HasKey(GO_Time_Min_Pref)
            && PlayerPrefs.HasKey(GO_Time_Year_Pref)
            && PlayerPrefs.HasKey(GO_Time_DayOfYear_Pref))
        {
            //Save to local variables
            gameOverTimeHour = PlayerPrefs.GetInt(GO_Time_Hr_Pref); //hr
            gameOverTimeMin = PlayerPrefs.GetInt(GO_Time_Min_Pref); // min
            gameOverYear = PlayerPrefs.GetInt(GO_Time_Year_Pref);
            gameOverDayOfYear = PlayerPrefs.GetInt(GO_Time_DayOfYear_Pref);

            return true;
        }
        else {
            return false;
        }
    }

    //Save to PlayerPrefs
    //Overwrite or create if does not exist.
    void SetGameOverTimePrefs(int hr, int min, int year, int dayOfYear)
    {
        PlayerPrefs.SetInt(GO_Time_Hr_Pref,hr); //hr
        PlayerPrefs.SetInt(GO_Time_Min_Pref,min); // min
        PlayerPrefs.SetInt(GO_Time_Year_Pref,year); // year
        PlayerPrefs.SetInt(GO_Time_DayOfYear_Pref,dayOfYear); // day of year

        PlayerPrefs.Save();
    }

    //Get from PlayerPrefs
    //returns false is key does not exist
    bool GetRewardAdTimePrefs()
    {
        //Ensure the Key exists in PlayerPrefs
        if (PlayerPrefs.HasKey(RA_Time_Hr_Pref)
            && PlayerPrefs.HasKey(RA_Time_Min_Pref)
            && PlayerPrefs.HasKey(RA_Time_Year_Pref)
            && PlayerPrefs.HasKey(RA_Time_DayOfYear_Pref))
        {
            //Save to local variables
            rewardedAdTimeHour = PlayerPrefs.GetInt(RA_Time_Hr_Pref); //hr
            rewardedAdTimeMin = PlayerPrefs.GetInt(RA_Time_Min_Pref); // min
            rewardedAdYear = PlayerPrefs.GetInt(RA_Time_Year_Pref);
            rewardedAdDayOfYear = PlayerPrefs.GetInt(RA_Time_DayOfYear_Pref);

            return true;
        }
        else
        {
            return false;
        }
    }

    //Save to PlayerPrefs
    //Overwrite or create if does not exist.
    void SetRewardedAdTimePrefs(int hr, int min, int year, int dayOfYear)
    {
        PlayerPrefs.SetInt(RA_Time_Hr_Pref, hr); //hr
        PlayerPrefs.SetInt(RA_Time_Min_Pref, min); // min
        PlayerPrefs.SetInt(RA_Time_Year_Pref, year); // year
        PlayerPrefs.SetInt(RA_Time_DayOfYear_Pref, dayOfYear); // day of year

        PlayerPrefs.Save();
    }

    void SetTimeNow()
    {
        timeNow = System.DateTime.UtcNow;
    }
    System.DateTime GetTimeNow()
    {
        SetTimeNow();
        return timeNow;
    }
    bool CheckGameOverCycle()
    {
        //Get time now
        GetTimeNow();
        GetGameOverTimePrefs();
        //Check time to see if one day has elapsed since last game over.
        //Is it the same year?
        if (timeNow.Year == gameOverYear)
        {
            //If yes then is today >= game over day + 1
            if (timeNow.DayOfYear >= gameOverDayOfYear + 1)
            {
                //If yes then if hour and min now >= hour and min of game over?
                if (timeNow.Hour >= gameOverTimeHour && timeNow.Minute >= gameOverTimeMin)
                {
                    //can play give starting lives
                    return true;

                }
            }
        }

        //Else if not but is next year
        else if (timeNow.Year == gameOverYear + 1)
        {
            //if yes then it better be the first day of this year and last day of last year.      
            if (timeNow.DayOfYear == 0 && (gameOverDayOfYear == 365 || gameOverDayOfYear == 366))
            {
                //if todays hour and min is >= game over hour and min
                if (timeNow.Hour >= gameOverTimeHour && timeNow.Minute >= gameOverTimeMin)
                {
                    //can play give starting lives
                    //can play
                    return true;
                }
            }
        }
        //else it has not been enough time.
        //
        return false;


    }

    public void PlayedRewardedAdJustNow()
    {
        GetTimeNow();

        SetRewardedAdTimePrefs(timeNow.Hour,timeNow.Minute,timeNow.Year,timeNow.DayOfYear);

        gameLogic.RestartGame();

    }

    public void GameOverNow()
    {
        GetTimeNow();

        SetGameOverTimePrefs(timeNow.Hour, timeNow.Minute, timeNow.Year, timeNow.DayOfYear);
    }

    public int GetHighschorePref()
    {
        

        if (PlayerPrefs.HasKey(Player_HighScore_Pref))
        {
            return PlayerPrefs.GetInt(Player_HighScore_Pref);
        }

        return -1;
    }

    public void SetHighscorePref(int newHighScore)
    {
        PlayerPrefs.SetInt(Player_HighScore_Pref, newHighScore);
        PlayerPrefs.Save();
    }

}
