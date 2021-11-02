using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipSplash : MonoBehaviour
{

    public Button skipBttn;
    // Start is called before the first frame update
    void Start()
    {
        skipBttn.onClick.AddListener(SkipSplashScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SkipSplashScreen()
    {
        SceneManager.LoadScene(1);
    }


}
