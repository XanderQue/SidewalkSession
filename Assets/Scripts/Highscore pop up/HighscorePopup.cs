using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscorePopup : MonoBehaviour
{
    public GameObject popup;
    private Button popBttn;
    public RectTransform rectTransform;
    public Text rank;
    public float popupSpeed = 1.0f;
    public ParticleSystem nuts;
    public ParticleSystem screws;

    private bool popupnow = false;
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        
        popBttn = popup.GetComponent<Button>();
        popBttn.onClick.AddListener(() => ResetBox());
        ResetBox();
    }
    // Update is called once per frame
    void Update()
    {
        if (popup)
        {
            if (rectTransform.localScale.x < 1.0f && rectTransform.localScale.y < 1.0f)
            {
                scale = rectTransform.localScale;
                scale.x = scale.x + Time.deltaTime * popupSpeed;
                scale.y = scale.x;
                Debug.Log("Update size : " + scale.x);
                rectTransform.localScale = scale;
            }
        }
    }

    public void ResetBox()
    {
        Debug.Log("Reset Box");
        popupnow = false;
        if(popup != null)
            popup.SetActive(false);
        scale.x = 0;
        scale.y = 0;
        rectTransform.localScale = scale;
    }

    public void PopUp(int newRank)
    {
        Debug.Log("Pop up Box with rank : "+ newRank);
        rank.text = "#" + newRank + "!";
        popupnow = true;
        if (popup != null)
            popup.SetActive(true);
        
        nuts.Play();
        screws.Play();
  


    }
}
