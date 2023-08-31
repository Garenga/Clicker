using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverPanel : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public GameObject panel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.SetActive(true);
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panel.SetActive(false);
        Debug.Log("Mouse exit");
    }
}
