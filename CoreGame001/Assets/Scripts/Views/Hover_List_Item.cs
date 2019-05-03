using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Hover_List_Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{   
    Color standardColor;
    Color hoverColor;

    Image bg;

    void Start()
    {
        standardColor = new Color();
        ColorUtility.TryParseHtmlString("#009FDF", out standardColor);

        hoverColor = new Color();
        ColorUtility.TryParseHtmlString("#A2185B", out hoverColor);

        bg = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse enter");
        bg.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse exit");
        bg.color = standardColor;
    }
}
