using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenLogic : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas optionsMenuCanvas;

    //main menu buttons
    public Button startBttn;
    public Button optionsBttn;
    public Button quitBttn;

 

    // Start is called before the first frame update
    void Start()
    {
        //do not include parenthesis in add listener when specifying 
        //function to call
        startBttn.onClick.AddListener(StartGame);
        optionsBttn.onClick.AddListener(OpenOptions);
        quitBttn.onClick.AddListener(QuiteGame);

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //canvas.enabled = false;
        SceneManager.LoadScene(2);
        mainMenuCanvas.enabled = false;
    }

    public void OpenOptions()
    {
        mainMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = true;
    }

    public void QuiteGame()
    {
        mainMenuCanvas.enabled = false;
        //exit game
        Application.Quit();
    }

   
}
