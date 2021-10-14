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

    public Text destroyedText;
    public Text scoreText;
    public Text scorePopUpText;
    public Text speedText;
    public AudioSource audioSource;
    public int score = 0;
    private int numJumps = 0;

    public float speedMult = 1.0f;
    public float yMax = -11.0f;

    public bool alive = true;
    private bool playedAudio = false;
    private float playerXPos;
    private float flashTime = .75f;

    public Canvas gameCanvas;
    public Canvas pauseCanvas;

    public Canvas continueCanvas;

    public Button continueBttn;
    public Button quitBttn;
    public Text continueScore;

    public static float timeScaleStatic = 0.825f;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeScaleStatic;
        continueBttn.onClick.AddListener(RestartGame);
        quitBttn.onClick.AddListener(ExitToMain);

        if (player == null
            || destroyedText == null)
        {

        }
        else
        {
            playerXPos = player.transform.position.x;
            playerRig = player.GetComponent<Rigidbody2D>();
        }
        playedAudio = false;
        if (paused)
        {
            PauseGame();
        }

        //set Audio
        AudioListener.volume = staticOptions.volume / 100.0f;
        if (!staticOptions.musicOn)
        {
            AudioListener.volume = 0.0f;
        }
        Debug.Log("Start Music : " + staticOptions.volume + " : " + AudioListener.volume);


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
            playedAudio = true;
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
            continueCanvas.enabled = false;
            gameCanvas.enabled = true;
            score = 0;
            numJumps = -1; 
            playedAudio = false;
            alive = true;
            
            UpdateScore();

            playerMovementScript.Respawn();
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


    }
    public void ScorePopUpTextSet(int score)
    {
        Color newColor = scorePopUpText.color;
        newColor.a = 1.0f;
        scorePopUpText.color = newColor;
        scorePopUpText.text = "+"+ score.ToString();
    }

    public void ExitToMain()
    {
        SceneManager.LoadScene(1);
    }
}
