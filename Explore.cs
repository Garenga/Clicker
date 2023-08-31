using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Explore : MonoBehaviour
{
    public Slider sliderPeople;
    public Slider sliderDays;
    public Button thisButton;

    public Button huntButton;
    public Button raidButton;

    public TextMeshProUGUI notification;

    public int exploringParty;


    private void Start()
    {
        sliderPeople.maxValue = GameManager.instance.citizen;
    }

    private void Update()
    {
        sliderPeople.maxValue = GameManager.instance.citizen;
    }

    public void Exploring()
    {
        RandomEvents();
        Debug.Log(sliderPeople.value);
    }

    public void ExploringClick()
    {
        if(sliderPeople.value > 0)
        {
            Invoke(nameof(Exploring), sliderDays.value*GameManager.instance.timeDay);

            exploringParty = (int)sliderPeople.value;
            GameManager.instance.citizen -= exploringParty ;
            sliderPeople.maxValue = GameManager.instance.citizen;

            GameManager.instance.food -= 25;

            thisButton.interactable = false;
            sliderPeople.interactable = false;
            sliderDays.interactable = false;
        }
    }

    void RandomEvents()
    {
        int rng = Random.Range(0, 3);

        switch (rng)
        {
            case 0:
                notification.text += "You have found <color=#008000>hunting grounds</color>\n";
                huntButton.interactable=true;
                break;

            case 1:
                notification.text += "You have found <color=#008000>another town</color>\n";
                raidButton.interactable=true;
                break;

            case 2:
                notification.text += "Your people have returned <color=#FF0000>empty handed</color>\n";
                GameManager.instance.citizen += exploringParty;
                thisButton.interactable = true;
                sliderPeople.interactable = true;
                sliderDays.interactable = true;
                break;
        }
    }
}
