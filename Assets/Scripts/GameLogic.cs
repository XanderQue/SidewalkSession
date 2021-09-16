using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text scoreText;
    public AudioSource audioSource;
    public int score = 0;

    public float speedMult = 1.0f;
    public float yMax = -11.0f;

    public bool alive = true;
    private bool playedAudio = false;
    private float playerXPos;
    private float flashTime = .75f;




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
    }

    // Update is called once per frame
    void Update()
    {
        
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

        }
        if (checkAlive())
        {
            speedUpStart();
        }
        else
        {

            slowToStop();
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
            slowToStop();
            speedMult = 1.0f;
        }
        
    }

    public void updateScore()
    {
        scoreText.text = score.ToString();
        speedMult += 0.01f;
    }

    //After your match ends the spawnObject will stop. Start polling for restart press.
    public void RestartGame() // Presss from input
    {
        if (!alive && playerMovementScript.canSpawn)
        {
            destroyedText.text = "";
            score = 0;
            updateScore();
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
                Debug.Log("press pause");
                Time.timeScale = 0.0f;
                AudioListener.pause = true;
                paused = true;
                //start pause flash coroutine
                StartCoroutine(pauseFlash());
            }
            else if(paused)
            {
                Debug.Log("unpause");
                pauseText.text = "";
                Time.timeScale = 1.0f;
                AudioListener.pause = false;
                paused = false;
            }
        }
    }

    IEnumerator pauseFlash()
    {
        pauseText.text = "Paused";
        yield return new WaitForSecondsRealtime(flashTime);
        pauseText.text = "";
        if (paused)
        {
            yield return new WaitForSecondsRealtime(flashTime);
            StartCoroutine(pauseFlash());
        }
    }

    private void slowToStop()
    {
        if (speedMult > 0)
        {
          //  speedMult -= 0.1f * Time.deltaTime;
        }

    }
    private void speedUpStart()
    {
        if (speedMult < 1.0f)
        {
          //  speedMult += 0.1f * Time.deltaTime;
        }
    }
}
