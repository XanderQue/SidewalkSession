using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_InputManager : MonoBehaviour
{
    public GameObject uiCanvas;
    GraphicRaycaster uiRaycaster;
    PointerEventData pointerData;
    List<RaycastResult> clickResults;

    // Start is called before the first frame update
    void Start()
    {
        uiRaycaster = uiCanvas.GetComponent<GraphicRaycaster>();
        pointerData = new PointerEventData(EventSystem.current);
        clickResults = new List<RaycastResult>();

    }

    // Update is called once per frame
    void Update()
    {
        //check for mouse click
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            MouseClickHandler();
        }
    }

    void MouseClickHandler()
    {
        pointerData.position = Mouse.current.position.ReadValue();
        clickResults.Clear();

        uiRaycaster.Raycast(pointerData,clickResults);

        foreach (RaycastResult result in clickResults)
        {
            GameObject uiElement = result.gameObject;
            string elementName = uiElement.name;
            string elementTag = uiElement.tag;
            
            //add functionality here


        }
    }
}
