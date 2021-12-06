using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update

    private int playerLives = 0;
    private int maxLives = 3;

    public GameLogic gameLogic;
    public PlayerPrefsLogic playerPrefsLogic;

    void Start()
    {
        if (gameLogic != null)
            gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLives()
    {
        playerLives = playerPrefsLogic.GetLivesPref();
        if (gameLogic != null)
            gameLogic.SetLivesText(playerLives);
        return playerLives;
    }
    public int GiveLives(int numLives)
    {
        GetLives();
        playerLives += numLives;
        playerPrefsLogic.SetLivesPref(playerLives);
        if (gameLogic != null)
            gameLogic.SetLivesText(playerLives);
        return playerLives;
    }

    public int LooseLives(int numLivesLost)
    {
        GetLives();
        playerLives -= numLivesLost;
        playerPrefsLogic.SetLivesPref(playerLives);
        if (gameLogic != null)
            gameLogic.SetLivesText(playerLives);
        return playerLives;

    }

    public int SetLives(int numLives)
    {
        playerLives = numLives;
        playerPrefsLogic.SetLivesPref(numLives);
        if(gameLogic != null)
            gameLogic.SetLivesText(playerLives);
        return playerLives;
    }
    public int SetMaxLives()
    {
        playerLives = maxLives;
        playerPrefsLogic.SetLivesPref(maxLives);
        if (gameLogic != null)
            gameLogic.SetLivesText(playerLives);
        return playerLives;
    }
}
