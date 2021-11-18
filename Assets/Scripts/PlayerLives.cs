using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update

    private int playerLives = 0;
    private int maxLives = 5;

    public GameLogic gameLogic;
    public PlayerPrefsLogic playerPrefsLogic;

    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveLives(int numLives)
    {
        playerLives += numLives;
    }

    public void LooseLives(int numLivesLost)
    {
        playerLives -= numLivesLost;
        /*if (playerLives < 0)
        {
            //Game over must watch add
            //or watch extended video
            
             
        }*/
    }
}
