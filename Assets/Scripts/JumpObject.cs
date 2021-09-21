using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : MonoBehaviour
{

    public int points = 1;
    private PlayerMovement player;
    private float playerPosition;
    private float currPosition;

    private bool scored = false;
    private GameLogic gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        gameLogic = GameObject.FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position.x;
        currPosition = transform.position.x;
        if (playerPosition > currPosition && !scored)
        {
            scored = true;
            gameLogic.score += Mathf.RoundToInt(gameLogic.speedMult * points);

            gameLogic.ScorePopUpTextSet(Mathf.RoundToInt(gameLogic.speedMult * points));

            gameLogic.updateScore();
        }

    }
}
