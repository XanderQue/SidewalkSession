using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static bool paused = false;
    public static float global_SpeedMultiplyer = 0.775f;

    public PlayerMovement playerMovementScript;
    public GameObject player;
    public Rigidbody2D playerRig;
    public SpawnObjectHere trashCanSpawner;
    //public PlayGameServices playGameServices;

    public AdManager adManager;
    public PlayerPrefsLogic playerPrefsLogic;
    public PlayerLives playerLives;

    public Text destroyedText;
    public Text scoreText;
    public Text highscoreText;
    public Text scorePopUpText;
    public Text speedText;
    public AudioSource audioSource;

    public int score = 0;
    
    public int highscore = 0;
    private int numJumps = 0;

    public float speedMult = .775f;
    public float yMax = -11.0f;

    public bool alive = true;
    private bool playedAudio = false;
    private float playerXPos;
    private float flashTime = .75f;

    public Canvas gameCanvas;
    public Canvas pauseCanvas;
    public Canvas howToPlayCanvas;
    public Toggle showHowToOnStart;

    public Canvas continueCanvas;

    public Button continueBttn;
    public Button watchAdGameOverBttn;
    public Button watchRewardBttn;

    public GameObject continueBttn_GameObject;
    public GameObject watchAdContinueButton_GameObject;
    public GameObject watchRewardAdBttn_GameObject;
    public GameObject rewardActiveBttn_GameObject;

    public Button quitBttn;
    public Text rewardActiveText;
    public Text continueScore;
    public Text continuePopUpText;
    public Text playerLivesContinue;
    public Text playerLivesPause;

    public string rewaredTimerString = " Min Lefts";

    public static float timeScaleStatic = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        if (playerPrefsLogic.ShowHowToPlayOnStart())
        {
            ShowHowTo();
        }
        else
        {
            StartGame();
        }








    }
    void StartGame()
    {
        Debug.Log("Should not show up yet");
        SetLivesText(playerLives.GetLives());
        Start_HighScore();
        Start_TimeScale(); // Set time to zero check lives
        Start_ButtonListeners();//Check if can play before starting time.
        Start_PlayerPhysics();
        playerPrefsLogic.CheckLivesPlayerPrefs();
        //What does this do?
        playedAudio = false;
        if (paused)
        {
            PauseGame();
        }
        // end : What does this do?


        Start_AudioVolume();

    }
    public void ShowHowTo()
    {
        if (playerPrefsLogic.ShowHowToPlayOnStart())
        {
            Time.timeScale = 0.0f;
            //freeze time show how to canvas.
            howToPlayCanvas.enabled = true;
            
        }
    }
    public void HideHowTo()
    {
        //hide how to canvas
        //unfreeze
        playerPrefsLogic.SetShowHowToPlayPref(showHowToOnStart.isOn);
        howToPlayCanvas.enabled = false;
        Time.timeScale = 1.0f;
        StartGame();
    }

    void Start_HighScore()
    {
        highscore = playerPrefsLogic.GetHighschorePref();

        if (highscore != -1)
        {
            highscoreText.text = highscore.ToString();
        }
    }
    void Start_TimeScale()
    {
        Time.timeScale = 0;
    }
    bool Start_GO_Status()
    {
        //check if lives available
        //if so then can press continue 


        return false;
    }
    void Start_ButtonListeners()
    {
        continueBttn.onClick.AddListener(() => ContinueWithAdBttn(false));
        watchAdGameOverBttn.onClick.AddListener(() => ContinueWithAdBttn(true));
        watchRewardBttn.onClick.AddListener(() => RewardAdBttn(true));
        
        quitBttn.onClick.AddListener(ExitGame);
    }
    void Start_PlayerPhysics()
    {
        playerXPos = player.transform.position.x;
        playerRig = player.GetComponent<Rigidbody2D>();

        Time.timeScale = 1.0f;
    }

   
    void Start_AudioVolume()
    {
        //set Audio
        AudioListener.volume = staticOptions.volume / 100.0f;
        if (!staticOptions.musicOn)
        {
            AudioListener.volume = 0.0f;
        }
        // Debug.Log("Start Music : " + staticOptions.volume + " : " + AudioListener.volume);
    }

    // Update is called once per frame
    void Update()
    {
        FadeAndAnimateScorePopUP();
    }
   
    private void FixedUpdate()
    {
            playerXPos = player.transform.position.x; 
            if(playerXPos < -11.0f)
            {
                GameOver();
                //press *start* to continue
            }
        if (speedMult != global_SpeedMultiplyer)
        {
            global_SpeedMultiplyer = speedMult;
            speedText.text = (Mathf.RoundToInt(global_SpeedMultiplyer*100)/100.0f).ToString();

        }
        if (CheckAlive())
        {
            SpeedUp();
        }
    }

    public void GameOver()
    {
        if (!playedAudio)
        {

            highscore = playerPrefsLogic.GetHighschorePref();
            


            if ( highscore < score)
            {
                playerPrefsLogic.SetHighscorePref(score);
                highscore = score;
                highscoreText.text = highscore.ToString();
                ScorePopUpTextSet(true, "NEW HIGH SCORE!");
            }

            //playGameServices.AddScoreToLeaderboard(highscore);
         
            playedAudio = true;

            //Begin Set Continue Canvas
            playerLives.LooseLives(1);
            //remove a life
            playerPrefsLogic.CheckLivesPlayerPrefs();//Sets continue canvas

            //End Set Continue Canvas
            gameCanvas.enabled = false;
            continueCanvas.enabled = true;
            //set continue canvas score
            continueScore.text = score.ToString();
            audioSource.Play();
            alive = false;
            playerRig.Sleep();
            speedMult = 1.0f;
        }
        
    }

       

    public void SetContinueBttnWatchAd()
    {
        continueBttn.enabled = false;
        continueBttn_GameObject.SetActive(false);
        watchAdGameOverBttn.enabled = true;
        watchAdContinueButton_GameObject.SetActive(true);

    }
    public void SetContinueBttnNoAd()
    {
        continueBttn.enabled = true;
        continueBttn_GameObject.SetActive(true);
        watchAdGameOverBttn.enabled = false;
        watchAdContinueButton_GameObject.SetActive(false);
    }

    public void SetRewardBttnWatchAd()
    {
        watchRewardBttn.enabled = true;
        watchRewardAdBttn_GameObject.SetActive(true);
        rewardActiveBttn_GameObject.SetActive(false);
    }

    public void SetRewardBttnNoOpt()
    {
        //Grey out reward button
        watchRewardBttn.enabled = false;
        watchRewardAdBttn_GameObject.SetActive(false);
        rewardActiveBttn_GameObject.SetActive(true);
        //set a text saying when it will expire******************************************     TO DO
    }
        
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
        numJumps++;
    }

    public int GetNumJumps()
    {
        return numJumps;
    }
    //After your match ends the spawnObject will stop. Start polling for restart press.
    public void RestartGame() // Presss from input
    {

        if (!alive && playerMovementScript.canSpawn)
        {
            trashCanSpawner.DeleteJumpObjects();
            continueCanvas.enabled = false;
            gameCanvas.enabled = true;
            score = 0;
            highscoreText.text = highscore.ToString();
            numJumps = -1; 
            playedAudio = false;
            alive = true;
            
            UpdateScore();
            playerMovementScript.Respawn();
            Time.timeScale = 1.0f;

        }
        
    }

    //public CheckAlive
    //This is used sent alive status.
    public bool CheckAlive()
    {
        return alive;
    }

    public void PauseGame()
    {

        if (alive)
        {
            SetLivesText(playerLives.GetLives());
            if (!paused) // pause
            {
                Time.timeScale = 0.0f;
                //AudioListener.pause = true;
                paused = true;
                gameCanvas.enabled = false;
                pauseCanvas.enabled = true;
            }
            else if (paused) // unpause
            {
                Time.timeScale = timeScaleStatic;
               // AudioListener.pause = false;
                paused = false;
                gameCanvas.enabled = true;
                pauseCanvas.enabled = false;
            }
        }
        else 
        {
            Time.timeScale = timeScaleStatic;
           // AudioListener.pause = false;
            paused = false;
            gameCanvas.enabled = true;
            pauseCanvas.enabled = false;
        }
    }



    
    private void SpeedUp()
    {
        if (speedMult < 1.0f)
        {
            speedMult += 0.1f * Time.deltaTime;
        }
    }


    private void FadeAndAnimateScorePopUP()
    {
        //fade to transparent
        if (scorePopUpText.color.a > 0.0f)
        {
            Color newColor = scorePopUpText.color;
            newColor.a -= 0.775f * Time.deltaTime;
            scorePopUpText.color = newColor;
        }
        if (continuePopUpText.color.a > 0.0f)
        {
            Color newColor = continuePopUpText.color;
            newColor.a -= 0.775f * Time.deltaTime;
            continuePopUpText.color = newColor;
        }

    }
    public void ScorePopUpTextSet(bool highscore ,string score)
    {
        Color newColor = scorePopUpText.color;
        newColor.a = 1.0f;
        if (highscore)
        {
            continuePopUpText.color = newColor;
            continuePopUpText.text = score;
        }
        else {
            scorePopUpText.color = newColor;
            scorePopUpText.text = "+" + score;
        }
        
    }

    public void ExitToMain()
    {


        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Time.timeScale = 1.0f;
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
            RestartGame();
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

    public void SetLivesText(int lives)
    {
        string livesText = "Lives : ";
        playerLivesContinue.text = livesText + lives;
        playerLivesPause.text = livesText + lives; ;
    }

}
