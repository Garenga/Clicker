using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RandomEvents
{
    Flood,
    Famine,
    Usual,
    Festival,
    Drought,
    GoodHarvest,
    Housefire,
    Raided,
    BabyBoom,
    WarEfforts,
    Plague
}

public class EventManager : MonoBehaviour
{
    //int eventDay = GameManager.instance.days;
    int rngEvent;
    public TextMeshProUGUI notifications;

    RandomEvents events;

    private void Start()
    {
        GameManager.instance.onEventDay.AddListener(RandomEventEfects);
    }

    private void SettingRandomEvent()
    {

        rngEvent = Random.Range(0, 101);

        if (rngEvent >= 0 && rngEvent <= 8)
        {
            events = RandomEvents.BabyBoom;
        }
        if (rngEvent >= 9 && rngEvent <= 18)
        {
            events = RandomEvents.Famine;
        }
        if (rngEvent >= 19 && rngEvent <= 28)
        {
            events = RandomEvents.Flood;
        }
        if (rngEvent >= 29 && rngEvent <= 63)
        {
            events = RandomEvents.Usual;
        }
        if (rngEvent >= 64 && rngEvent <= 73)
        {
            events = RandomEvents.Drought;
        }
        if (rngEvent >= 74 && rngEvent <= 83)
        {
            events = RandomEvents.Housefire;
        }
        if (rngEvent >= 84 && rngEvent <= 90)
        {
            events = RandomEvents.Raided;
        }
        if (rngEvent >= 91 && rngEvent <= 100)
        {
            events = RandomEvents.WarEfforts;
        }

    }

    private void RandomEventEfects()
    {

        SettingRandomEvent();

        switch (events)
        {
            case RandomEvents.BabyBoom:
                GameManager.instance.citizen += Random.Range(15, 25);
                notifications.text = "Event : Baby Boom\n";
                break;

            case RandomEvents.Famine:
                
                GameManager.instance.food -= Random.Range(25, 35);
                if (GameManager.instance.food < 0)
                {
                    GameManager.instance.food = 0;
                }
                notifications.text = "Event : Famine\n";
                break;

            case RandomEvents.Flood:
                
                BuildingsManager.bInstance.numberOfBuildingsFarms -= Random.Range(5, 12);
                BuildingsManager.bInstance.numberOfBuildingsHouse -= Random.Range(2, 8);

                if (BuildingsManager.bInstance.numberOfBuildingsFarms<0)
                {
                    BuildingsManager.bInstance.numberOfBuildingsFarms = 0;
                }
                if (BuildingsManager.bInstance.numberOfBuildingsHouse < 0)
                {
                    BuildingsManager.bInstance.numberOfBuildingsHouse = 0;
                }
                notifications.text = "Event : Flood\n";
                break;

            case RandomEvents.Usual:
                notifications.text = "Everything is as usual\n";
                break;

            case RandomEvents.Drought:
                GameManager.instance.food -= BuildingsManager.bInstance.foodProduction * BuildingsManager.bInstance.numberOfBuildingsFarms;
                notifications.text = "Event : Drought\n";
                break;

            case RandomEvents.Housefire:
                BuildingsManager.bInstance.numberOfBuildingsHouse -= Random.Range(8, 15);
                if (BuildingsManager.bInstance.numberOfBuildingsHouse < 0)
                {
                    BuildingsManager.bInstance.numberOfBuildingsHouse = 0;
                }
                notifications.text = "Event : Housefires\n";
                break;

            case RandomEvents.Raided:
                GameManager.instance.gold -= Random.Range(35, 150);
                if (GameManager.instance.soldier < 40)
                {
                    GameManager.instance.citizen -= Random.Range(10, 30);
                    notifications.text = "Event : Raided\nSome citizens were captured\n";
                }
                notifications.text = "Event : Raided\n";
                break;

            case RandomEvents.WarEfforts:
                GameManager.instance.gold -= 75;
                if (GameManager.instance.soldier > 25)
                {
                    GameManager.instance.soldier -= Random.Range(8, 20);
                    notifications.text = "Event : WarEfforts\nSome soldier decided to join\n";
                }
                notifications.text = "Event : WarEfforts\n";
                break;
        }
    }
}
