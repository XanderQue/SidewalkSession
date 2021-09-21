using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static bool paused = false;
    public static float global_SpeedMultiplyer = 1.0f;

    public PlayerMovement playerMovementScript;
    public GameObject player;
    public Rigidbody2D playerRig;
    public SpawnObjectHere trashCanSpawner;

    public Text destroyedText;
    public Text pauseText;
    public Text pauseQuitText;
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

    private List<Coroutine> coroutines;


    // Start is called before the first frame update
    void Start()
    {
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
            pauseGame();
        }
        
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
            speedText.text = global_SpeedMultiplyer.ToString();

        }
        if (checkAlive())
        {
            speedUp();
        }
    }

    public void GameOver()
    {
        if (!playedAudio)
        {
            playedAudio = true;
            destroyedText.text = "Game Over";
            audioSource.Play();
            alive = false;
            playerRig.Sleep();
            speedMult = 1.0f;
        }
        
    }

    public void updateScore()
    {
        scoreText.text = score.ToString();
        //speedMult += 0.01f;
        numJumps++;
    }

    public int getNumJumps()
    {
        return numJumps;
    }
    //After your match ends the spawnObject will stop. Start polling for restart press.
    public void RestartGame() // Presss from input
    {
        if (!alive && playerMovementScript.canSpawn)
        {
            destroyedText.text = "";
            score = 0;
            numJumps = -1; 
            playedAudio = false;
            alive = true;
            
            updateScore();

            playerMovementScript.respawn();
        }
        
    }

    //public checkAlive
    //This is used sent alive status.
    public bool checkAlive()
    {
        return alive;
    }

    public void pauseGame()
    {

        if (alive)
        {

            if (!paused)
            {
                Time.timeScale = 0.0f;
                AudioListener.pause = true;
                paused = true;
                //start pause flash coroutine
               coroutines.Add(StartCoroutine(pauseFlash()));
            }
            else if (paused)
            {
                Debug.Log("unpause");
                pauseText.text = "";
                pauseQuitText.text = "";
                Time.timeScale = 1.0f;
                AudioListener.pause = false;
                paused = false;
                foreach (Coroutine corout in coroutines)
                {
                    StopCoroutine(corout);
                }
            }
        }
        else 
        {
            pauseText.text = "";
            pauseQuitText.text = "";
            Time.timeScale = 1.0f;
            AudioListener.pause = false;
            paused = false;
        }
    }

    IEnumerator pauseFlash()
    {
        if (paused)
        {
            pauseText.text = "Paused";
            pauseQuitText.text = "Press \'Q\', Select(Gamepad) or View(Xbox) to quit to title screen";
            yield return new WaitForSecondsRealtime(flashTime);
            pauseText.text = "";

            yield return new WaitForSecondsRealtime(flashTime);
            coroutines.Add(StartCoroutine(pauseFlash()));
            
           
        }
        else
        {
            pauseText.text = "";
            pauseQuitText.text = "";
        }

    }

    
    private void speedUp()
    {
        if (speedMult < 1.0f + score *0.005f)
        {
            speedMult += 0.1f * Time.deltaTime;
        }
    }

    public void quiteToTitle()
    {
        if(paused)
        {
            pauseGame();
            SceneManager.LoadScene(0);

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
}
