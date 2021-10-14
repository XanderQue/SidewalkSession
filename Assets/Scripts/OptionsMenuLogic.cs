using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuLogic : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas optionsMenuCanvas;

    //option menu buttons
    public Button musicOnBttn;
    public Button musicOffBttn;
    public Button backBttn;
    public Slider volumeSldr;
    public Text volumeValueText;
    // Start is called before the first frame update
    void Start()
    {
        //set Options buttons
        musicOnBttn.onClick.AddListener(TurnOnMusic);
        musicOffBttn.onClick.AddListener(TurnOffMusic);
        volumeSldr.onValueChanged.AddListener(OnVolumeSet);
        backBttn.onClick.AddListener(GoBackToMain);

        // set music options based on const bool
        //for now.. do manual
        musicOnBttn.interactable = !staticOptions.musicOn;
        musicOffBttn.interactable = staticOptions.musicOn;
        volumeValueText.text = staticOptions.volume.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeSldr.value != staticOptions.volume)
        {
            volumeSldr.value = staticOptions.volume;
        }
    }

    public void TurnOnMusic()
    {
        musicOnBttn.interactable = false;
        musicOffBttn.interactable = true;
        staticOptions.musicOn = true;
        staticOptions.volume = 100;
        AudioListener.volume = 1.0f;

    }

    public void TurnOffMusic()
    {
        musicOnBttn.interactable = true;
        musicOffBttn.interactable = false;
        staticOptions.musicOn = false;
        staticOptions.volume = 0;
        AudioListener.volume = 0.0f;
    }

    public void GoBackToMain()
    {

        optionsMenuCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
    }

    public void OnVolumeSet(float newVal)
    {
        int newVolume = Mathf.RoundToInt(newVal);
        staticOptions.volume = newVolume;
        volumeValueText.text = newVolume + "%";
        AudioListener.volume = newVolume / 100.0f;
    }
}
