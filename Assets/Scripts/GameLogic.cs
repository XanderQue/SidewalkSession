using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public GameObject player;
    public Rigidbody2D playerRig;
    public SpawnObjectHere trashCanSpawner;

    public Text destroyedText;
    public Text scoreText;
    public AudioSource audioSource;
    public int score = 0;
    public float yMax = -11.0f;

    public bool alive = true;
    private bool playedAudio = false;
    private float playerXPos;
    
 
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

        }
        
    }

    public void updateScore()
    {
        scoreText.text = score.ToString();
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
}
