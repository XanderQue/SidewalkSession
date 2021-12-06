using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HowToPlayPageLogic : MonoBehaviour
{
    public Canvas howToPlayPage;
    public Toggle showHowToOnStart;
    public PlayerPrefsLogic playerPrefsLogic;

    private Canvas previous;
   

    public void OpenHowToCanvas(Canvas current)
    {
        previous = current;
        previous.enabled = false;
        howToPlayPage.enabled = true;
    }
    public void CloseHowToCanvas()
    {
        playerPrefsLogic.SetShowHowToPlayPref(showHowToOnStart.isOn);
        previous.enabled = true;
        howToPlayPage.enabled = false;
    }
    

}
