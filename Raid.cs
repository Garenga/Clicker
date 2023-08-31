using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Raid : MonoBehaviour
{
   // public Slider slider;
    public Button thisButton;

    public Explore exploreScript;
    public TextMeshProUGUI notifications;
    public int people;

    private void Start()
    {
        people = exploreScript.exploringParty;
        thisButton.interactable = false;
    }

    public void Raiding()
    {
        int rng=Random.Range(0,3);

        switch (rng) 
        {
            case 0:
                notifications.text += "<color=#FF0000>Raid failed</color>\n";
                GameManager.instance.citizen -= people;
                break; 

            case 1:
                int foodRNGmid = Random.Range((int)(people)+5, (int)(people * 2)+10);
                int stoneRNGmid = Random.Range((int)(people)+5, (int)(people * 1.5f)+10);
                int woodRNGmid = Random.Range((int)(people * 0.5f)+5, (int)(people))+10;
                int popRNGmid = Random.Range((int)(people * 0.1f)+5, (int)(people * 0.5f)+10);

                GameManager.instance.food +=foodRNGmid;
                GameManager.instance.stone +=stoneRNGmid ;
                GameManager.instance.wood += woodRNGmid;
                GameManager.instance.citizen -= popRNGmid;

                //notifications.text += "You did something";
                notifications.text += string.Format("<color=#008000>You did something. Raid got {0:0} food, {1:0} stone, {2:0} wood and lost {3:0} people</color>\n", foodRNGmid, stoneRNGmid, woodRNGmid, popRNGmid);

                break; 
            case 2:
                int foodRNGsucc = Random.Range((int)(people)+10, (int)(people * 2)+20);
                int stoneRNGsucc = Random.Range((int)(people)+10, (int)(people * 1.5f)+20);
                int woodRNGsucc = Random.Range((int)(people * 0.5f)+10, (int)(people)+20);
                int popRNGsucc = Random.Range((int)(people * 0.5f)+10, (int)(people)+20);
                int goldRNGsucc= Random.Range((int)(people * 0.5f)+10, (int)(people)+20);

                GameManager.instance.food += foodRNGsucc;
                GameManager.instance.stone += stoneRNGsucc;
                GameManager.instance.wood +=woodRNGsucc;
                GameManager.instance.citizen += popRNGsucc;
                GameManager.instance.gold += goldRNGsucc;

                notifications.text += string.Format("<color=#008000>You did good. Raid got {0:0} food, {1:0} stone, {2:0} wood and gained {3:0} people</color>\n", foodRNGsucc,stoneRNGsucc,woodRNGsucc,popRNGsucc);
                break;
        }


        //thisButton.interactable = true;
        //slider.interactable = true;

        exploreScript.sliderDays.interactable = true;
        exploreScript.sliderPeople.interactable = true;
        exploreScript.thisButton.interactable = true;

        //Debug.Log(slider.value);

    }

    public void RaidClick()
    {
        Invoke(nameof(Raiding), 8f);

        //slider.maxValue = GameManager.instance.population;

        thisButton.interactable = false;
        //slider.interactable = false;
    }
}
