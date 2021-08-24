using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreenLogic : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI pressSpace;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitFlash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        canvas.enabled = false;
        SceneManager.LoadScene(1);
    }

    IEnumerator waitFlash()
    {
        yield return new WaitForSeconds(0.75f);
        pressSpace.alpha = 0.0f;
        yield return new WaitForSeconds(0.5f);
        pressSpace.alpha = 1.0f;
        StartCoroutine(waitFlash());
        
    }
}
