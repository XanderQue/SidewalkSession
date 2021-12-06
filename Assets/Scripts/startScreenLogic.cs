using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenLogic : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas optionsMenuCanvas;

    public AdManager adManager;
    public PlayerPrefsLogic playerPrefsLogic;
    public PlayerLives playerLives;
    public HowToPlayPageLogic howToPlayPageLogic;

    //main menu buttons
    public GameObject startButton_GameObject;
    public GameObject startWithAdButton_GameObject;
    public GameObject noAdsButton_GameObject;
    public GameObject rewardAdButton_GameObject;

    public Button startBttn;
    public Button startWithAdBttn;
    public Button rewardedAdBttn;
    public Button optionsBttn;
    public Button howToPlayPageBttn;
    public Button quitBttn;

    public Text playerLivesStart;
    public Text rewardTimeText;
    public string rewardTimeString = " Min Left\nFor no Ads";

 

    // Start is called before the first frame update
    void Start()
    {
        //do not include parenthesis in add listener when specifying 
        //function to call
        startBttn.onClick.AddListener(() => ContinueWithAdBttn(false));
        startWithAdBttn.onClick.AddListener(()=> ContinueWithAdBttn(true));
        rewardedAdBttn.onClick.AddListener(() => RewardAdBttn(true));

        optionsBttn.onClick.AddListener(OpenOptions);
        howToPlayPageBttn.onClick.AddListener(OpenHowToPage);
        quitBttn.onClick.AddListener(QuiteGame);

        playerPrefsLogic.CheckLivesPlayerPrefs();
        
        SetLivesText();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       
    }
    public void StartGame()
    {
        //canvas.enabled = false;
        SceneManager.LoadScene(2);//3 is loading scene 10/24/2021
        mainMenuCanvas.enabled = false;
    }

    public void OpenOptions()
    {
        mainMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = true;
    }

    public void QuiteGame()
    {
        mainMenuCanvas.enabled = false;
        //exit game
        Application.Quit();
    }

    public void ContinueWithAdBttn(bool watchAd)
    {
        if (watchAd)
        {
            adManager.PlayAd();
        }
        else
        {
            StartGame();
        }
    }
    public void RewardAdBttn(bool watchAd)
    {
        if (watchAd)
        {
            //do rewarded ad stuff/
            adManager.PlayRewaredeAd();
        }
    }

   void SetLivesText()
    {   
        string livesText = "Lives : ";
        playerLivesStart.text = livesText + playerLives.GetLives();
    }


    public void SetContinueBttnWatchAd()
    {
        startBttn.enabled = false;
        startButton_GameObject.SetActive(false);
        startWithAdBttn.enabled = true;
        startWithAdButton_GameObject.SetActive(true);

    }
    public void SetContinueBttnNoAd()
    {
        startBttn.enabled = true;
        startButton_GameObject.SetActive(true);
        startWithAdBttn.enabled = false;
        startWithAdButton_GameObject.SetActive(false);
    }

    public void SetRewardBttnWatchAd()
    {
        rewardedAdBttn.enabled = true;
        rewardAdButton_GameObject.SetActive(true);
        noAdsButton_GameObject.SetActive(false);
    }
    public void SetRewardBttnNoOpt()
    {
        //Grey out reward button
        rewardedAdBttn.enabled = false;

        rewardAdButton_GameObject.SetActive(false);
        noAdsButton_GameObject.SetActive(true);
        //set a text saying when it will expire******************************************     TO DO
    }

    void OpenHowToPage()
    {
        howToPlayPageLogic.OpenHowToCanvas(mainMenuCanvas);
    }
}
