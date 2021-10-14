using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreenLogic : MonoBehaviour
{

    public GameLogic gameLogic;


    //public Canvas gameCanvas;
    public Canvas pauseCanvas;
    public Canvas optionsCanvas;
    public Canvas exitCanvas;


    //Pause buttons
    public Button unPauseBttn;
    public Button optionsBttn;
    public Button exitMenuBttn;

    //Exit Option buttons
    public Button toMainBttn;
    public Button exitBttn;
    public Button exitCancelBttn;


    // Start is called before the first frame update
    void Start()
    {
        //Add listeners for pause screen
        unPauseBttn.onClick.AddListener(Unpause);
        optionsBttn.onClick.AddListener(GoToOptionsMenu);
        exitMenuBttn.onClick.AddListener(GoToExitMenu);

        //Add listeners for exit menu
        toMainBttn.onClick.AddListener(LoadMainMenu);
        exitBttn.onClick.AddListener(ExitGame);
        exitCancelBttn.onClick.AddListener(CancelExit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Unpause()
    {
        gameLogic.PauseGame();
    }

    public void GoToOptionsMenu()
    {
        pauseCanvas.enabled = false;
        optionsCanvas.enabled = true;
    }

    public void GoToExitMenu()
    {
        pauseCanvas.enabled = false;
        exitCanvas.enabled = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void CancelExit()
    {
        exitCanvas.enabled = false;
        pauseCanvas.enabled = true;
    }
}
