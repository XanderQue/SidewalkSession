using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPrefsLogic : MonoBehaviour
{
    static string GO_Time_Hr_Pref = "GO_Time_Hr";
    static string Go_Time_Min_Pref ="GO_Time_MIN";
    static string Go_Time_Year_Pref ="GO_Time_Year";
    static string Go_Time_DayOfYear_Pref = "GO_Time_DayOfYear";

    static string Player_Lives_Pref = "Player_Lives";

    static string RA_Time_Hr_Pref = "RA_Time_Hr";
    static string RA_Time_Min_Pref = "RA_Time_MIN";
    static string RA_Time_Year_Pref = "RA_Time_Year";
    static string RA_Time_DayOfYear_Pref = "RA_Time_DayOfYear";


    int playerLives = 0;

    int[] gameOverTimeInHMS; // [hr][min][sec]
    int gameOverDayOfYear = 0; // out of 365/366
    int gameOverYear = 0;

    int[] rewardedAdTimeInHMS; //[hr][min][sec]
    int rewardedAdDayOfYear = 0; // out of 365
    int rewardedAdYear = 0;

    System.DateTime rewardedAdTime;
    System.DateTime timeNow;


    int gameOverTimeOut = 1; // in Hrs

    // Start is called before the first frame update
    void Start()
    {
        gameOverTimeInHMS = new int[3];
        gameOverTimeInHMS[0] = 0; //hr
        gameOverTimeInHMS[1] = 0; // min
        gameOverTimeInHMS[2] = 0; // sec

        rewardedAdTimeInHMS = new int[3];
        rewardedAdTimeInHMS[0] = 0;
        rewardedAdTimeInHMS[1] = 0;
        rewardedAdTimeInHMS[2] = 0;

        timeNow = System.DateTime.Now;


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
            

        }
        else 
        {
            PlayerPrefs.SetInt("FirstTime", 0);
        }
    }

    bool GetGameOverTimePrefs()
    {
        if (PlayerPrefs.HasKey("GO_Time_HR")
            && PlayerPrefs.HasKey("GO_Time_MIN")
            && PlayerPrefs.HasKey("GO_Time_Year")
            && PlayerPrefs.HasKey("GO_Time_DayOfYear"))
        {

            gameOverTimeInHMS[0] = PlayerPrefs.GetInt("GO_Time_HR"); //hr
            gameOverTimeInHMS[1] = PlayerPrefs.GetInt("GO_Time_MIN"); // min
            gameOverYear = PlayerPrefs.GetInt("GO_Time_Year");
            gameOverDayOfYear = PlayerPrefs.GetInt("GO_Time_DayOfYear");

            return true;
        }
        else {
            return false;
        }
    }

    void SetGameOverTimePrefs(int hr, int min, int year, int dayOfYear)
    {
        PlayerPrefs.SetInt("GO_Time_HR",hr); //hr
        PlayerPrefs.SetInt("GO_Time_MIN",min); // min
        PlayerPrefs.SetInt("GO_Time_Year",year); // year
        PlayerPrefs.SetInt("GO_Time_DayOfYear",dayOfYear); // day of year
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

        //Get Now Time
        int[] timeNowHM = new int[2];
        int dayOfYearNow = 0;
        int yearNow = 0;
        System.DateTime timeNow = System.DateTime.Now;

        dayOfYearNow = timeNow.DayOfYear;
        yearNow = timeNow.Year;

        timeNowHM[0] = timeNow.Hour;
        timeNowHM[1] = timeNow.Minute;
        //DONE Get Now Time

        //Get Game Over TIme



        //has it been more than a year!?
        if (yearNow <= gameOverYear)
        {
            //is it still today?
            //if yes do nothing
            //else if its tomorrow
            //then if game Over hour < now hour?
            //if yes then is game over min < now min?
            //if yes then can continue without ad!
            //
            //
        }
        else 
        {
            // no ad required [ ]
        }

    }
}
