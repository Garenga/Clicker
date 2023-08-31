using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Hunt : MonoBehaviour
{
   // public Slider slider;
    public Button thisButton;

    public Explore exploreScript;
    public TextMeshProUGUI notifications;

    private void Start()
    {
        //slider.maxValue = GameManager.instance.population;
        thisButton.interactable = false;
    }

    public void Hunting()
    {
        int huntRNG = Random.Range(5, 20+(int)exploreScript.sliderDays.value + 3*(int)exploreScript.sliderPeople.value);

        GameManager.instance.food +=huntRNG;
        //thisButton.interactable = true;

        notifications.text += string.Format("You gathered <color=#008000>{0:0} food.</color>\n", huntRNG);
       // slider.interactable = true;
       // Debug.Log(slider.value);

        exploreScript.sliderDays.interactable = true;
        exploreScript.sliderPeople.interactable = true;
        exploreScript.thisButton.interactable = true;

        //this.gameObject.SetActive(false);
    }

    public void HuntClick()
    {
        Invoke(nameof(Hunting), 1f);
        //GameManager.instance.population -= (int)slider.value;
        //slider.maxValue = GameManager.instance.population;
        thisButton.interactable = false;
       // slider.interactable = false;
    }
}


