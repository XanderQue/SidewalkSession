using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreenLogic : MonoBehaviour
{

    public GameLogic gameLogic;
    public HowToPlayPageLogic howToPlayPageLogic;
    public AdManager adManager;

    //public Canvas gameCanvas;
    public Canvas pauseCanvas;
    public Canvas optionsCanvas;
    public Canvas exitCanvas;


    //Pause buttons
    public Button unPauseBttn;
    public Button optionsBttn;
    public Button howToPageBttn;

    //Exit Option buttons
    public Button exitBttn;
    public Button exitCancelBttn;


    // Start is called before the first frame update
    void Start()
    {
        //Add listeners for pause screen
        unPauseBttn.onClick.AddListener(Unpause);
        optionsBttn.onClick.AddListener(GoToOptionsMenu);
        howToPageBttn.onClick.AddListener(OpenHowToPage);

        //Add listeners for exit menu
        exitBttn.onClick.AddListener(ExitGame);
        exitCancelBttn.onClick.AddListener(CancelExit);
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


    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        Application.Quit();
    }
    public void CancelExit()
    {
        exitCanvas.enabled = false;
        pauseCanvas.enabled = true;
    }

    void OpenHowToPage()
    {
        howToPlayPageLogic.OpenHowToCanvas(pauseCanvas);
    }
}
