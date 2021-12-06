using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{

    public Text loadingText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation level = SceneManager.LoadSceneAsync(3);

        while (level.progress < 1)
        {
            yield return new WaitForSeconds(0.025f);
            int percentLoaded = Mathf.RoundToInt(level.progress * 100);
            loadingText.text = "Loading\n"+percentLoaded+"%";
            
            yield return new WaitForEndOfFrame();
        }
    }
}
