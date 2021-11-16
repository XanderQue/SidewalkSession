using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrefsLogic : MonoBehaviour
{
    public static string GO_Time_Hr_Pref = "GO_Time_Hr";
    public static string GO_Time_Min_Pref ="GO_Time_MIN";
    public static string GO_Time_Year_Pref ="GO_Time_Year";
    public static string GO_Time_DayOfYear_Pref = "GO_Time_DayOfYear";

    public static string Player_Lives_Pref = "Player_Lives";

    public static string RA_Time_Hr_Pref = "RA_Time_Hr";
    public static string RA_Time_Min_Pref = "RA_Time_MIN";
    public static string RA_Time_Year_Pref = "RA_Time_Year";
    public static string RA_Time_DayOfYear_Pref = "RA_Time_DayOfYear";

    bool rewardActive = false;
    bool hasLives = false;

    bool hasGO_Time_Prefs = false;
    bool hasRA_Time_Prefs = false;


    int playerLives = 0;

    int gameOverTimeHour = 0;
    int gameOverTimeMin = 0;
    int gameOverDayOfYear = 0; // out of 365/366
    int gameOverYear = 0;

    int rewardedAdTimeHour;
    int rewardedAdTimeMin;
    int rewardedAdDayOfYear = 0; // out of 365
    int rewardedAdYear = 0;

    System.DateTime rewardedAdTime;
    System.DateTime timeNow;


    int gameOverTimeOut = 1; // in Hrs

    // Start is called before the first frame update
    void Start()
    {

        //Get from playerprefs
        GetPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void GetPlayerPrefs()
    {

        if (PlayerPrefs.HasKey("FirstTime"))
        {
            //not first time
            hasRA_Time_Prefs = GetRewardAdTimePrefs();
            hasGO_Time_Prefs = GetGameOverTimePrefs();
        }
        else 
        {
            int startingLives = 3;
            PlayerPrefs.SetInt("FirstTime", 0);
            PlayerPrefs.SetInt(Player_Lives_Pref, startingLives);
            playerLives = startingLives;
        }
    }

    bool CheckRewardActive()
    {
        GetRewardAdTimePrefs();
        GetTimeNow();

        //check if reward ad is within one hour of watching
        //if its been over a year, its for sure not active
        if (rewardedAdYear == timeNow.Year)
        {
            //if same day
            if (timeNow.DayOfYear == rewardedAdDayOfYear)
            {
                //then is now hour == reward hour+1
                if (timeNow.Hour == rewardedAdTimeHour + 1)
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
    bool GetLives()
    {
        if (PlayerPrefs.HasKey(Player_Lives_Pref))
        {
            playerLives = PlayerPrefs.GetInt(Player_Lives_Pref);
            return true;
        }
        else
            return false;
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
    void SetrewardedAdTimePrefs(int hr, int min, int year, int dayOfYear)
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
    void CheckGameOverCycle()
    {
        //Get time now
        GetTimeNow();

       


    }

    void PlayedRewardedAd()
    {
        GetTimeNow();

        SetrewardedAdTimePrefs(timeNow.Hour,timeNow.Minute,timeNow.Year,timeNow.DayOfYear);

    }

    void GameOverNow()
    {
        GetTimeNow();

        SetGameOverTimePrefs(timeNow.Hour, timeNow.Minute, timeNow.Year, timeNow.DayOfYear);
    }
}
