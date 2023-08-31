using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject containerPanel;
    [SerializeField] Animator anim;

    private void Start()
    {
        StartCoroutine(TurnOffPanel());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        anim.SetTrigger("ButtonClicked");
        containerPanel.SetActive(!containerPanel.activeSelf);
    }

    IEnumerator TurnOffPanel()
    {
        yield return null;
        containerPanel.SetActive(false);
    }

}