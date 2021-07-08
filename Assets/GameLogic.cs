using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public GameObject player;
    public GameObject destroyedText;
    public AudioSource audioSource;

    private bool alive = true;
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
        }
        playedAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (alive) 
        { 
            playerXPos = player.transform.position.x; 
            if(playerXPos < -11.0f)
            {
                GameOver();
                //Freeze player.
                Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
                playerBody.freezeRotation = true;
                playerBody.gravityScale = 0.0f;

                //press *start* to continue
            }
        }


    }

    void GameOver()
    {
        destroyedText.active = true;
        if (!playedAudio)
        {
            audioSource.Play();
            playedAudio = true;
        }
        


        
    }
}
