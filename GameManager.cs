
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Resources")]
    public int wood;
    public int water;
    public int stone;
    public int food;
    public int gold;

    [Header("Pawns")]
    public int population;
    public int citizen;
    public int worker;
    public int soldier;
    public int house;

    [Header("Buildings")]
    public int lumbermill;
    public int well;
    public int quary;
    public int farms;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI woodText;
    [SerializeField] TextMeshProUGUI waterText;
    [SerializeField] TextMeshProUGUI stoneText;
    [SerializeField] TextMeshProUGUI foodText;
    [SerializeField] TextMeshProUGUI goldText;

    [SerializeField] TextMeshProUGUI populationText;
    [SerializeField] TextMeshProUGUI houseText;
    [SerializeField] TextMeshProUGUI citizenText;
    [SerializeField] TextMeshProUGUI solderText;
    [SerializeField] TextMeshProUGUI workerText;

    [SerializeField] TextMeshProUGUI daysText;

    [SerializeField] TextMeshProUGUI notifications;

    public static GameManager instance;//za static instancu GameManager-a
    public UnityEvent onDayOver;//UnityEvent, koriste ga skripte WeatherManager i IBuilding skripte
    public UnityEvent onEventDay;
    public int days=1;//ispisuje dane
    public float happines=1f;//dodatak koji se koristi u produkciji resursa
    public float timeDay=24f;
    public float seasonTime;
    public float eventTime;

    public Image[] seaons;
    public Image[] seaonsBackground;
    public int seasonIndex = 0;

    bool isGameOver;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        population = citizen + worker + soldier;
        house = citizen;
        seasonTime = 6 * timeDay;
        eventTime = 3 * timeDay;


        onDayOver.AddListener(PopulationSpending);//dodajemo metode koje ce se izvrsiti kad se event pozove
        onDayOver.AddListener(CreatePawn);
        onDayOver.AddListener(CalculateHappines);
        onDayOver.AddListener(CheckResources);
        StartCoroutine(PasageOfTime());//coroutine koja dodaje dane i poziva UnityEvent onDayOver
        StartCoroutine(SeasonChange());
        StartCoroutine(EventTimer());
        StartCoroutine(PopulationGoldGain());

        woodText.text = wood.ToString();
        waterText.text = water.ToString();
        stoneText.text = stone.ToString();
        foodText.text = food.ToString();
        goldText.text = gold.ToString();
        houseText.text = house.ToString();

        populationText.text = "Population: "+population.ToString();
        daysText.text = days.ToString()+". Day";

        for (int i = 0; i < seaons.Length; i++)
        {
            seaons[i].color = Color.gray;
            seaonsBackground[i].enabled = false;
        }

        seaons[seasonIndex].color = Color.white;
        seaonsBackground[seasonIndex].enabled = true;

    }

    private void Update()
    {
        population = citizen + soldier + worker;
        populationText.text = "Population: " + population.ToString();

        citizenText.text = "Citizen: " + citizen.ToString();
        solderText.text = "Soldiers: " + soldier.ToString();
        workerText.text = "Workers: " + worker.ToString();

        woodText.text = wood.ToString();
        waterText.text = water.ToString();
        stoneText.text = stone.ToString();
        foodText.text = food.ToString();

        goldText.text = gold.ToString();
    }

    IEnumerator PasageOfTime()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(timeDay);
            days++;
            daysText.text = days.ToString() + ". Day";
            onDayOver.Invoke();

            woodText.text = wood.ToString();
            waterText.text = water.ToString();
            stoneText.text = stone.ToString();
            foodText.text = food.ToString();
            goldText.text = gold.ToString();

        }
    }
    IEnumerator PopulationGoldGain()
    {
        while (!isGameOver)
        {
            gold += (int)(citizen);
            goldText.text = gold.ToString();
            yield return new WaitForSeconds(timeDay);

        }
    }

    IEnumerator SeasonChange()
    {
        while (!isGameOver) 
        {
            yield return new WaitForSeconds(seasonTime);

            for (int i = 0; i < seaons.Length; i++)
            {
                seaons[i].color = Color.gray;
                seaonsBackground[i].enabled = false;

            }

            seasonIndex++;

            if (seasonIndex < seaons.Length)
            {
                seaons[seasonIndex].color = Color.white;
                seaonsBackground[seasonIndex].enabled = true;
            }
            else
            {
                seasonIndex = 0;
                seaons[seasonIndex].color = Color.white;
                seaonsBackground[seasonIndex].enabled = true;
            }

            Debug.Log(seasonIndex);
            ItemsManager.iInstance.numberOfItemsClothing -= (int)Random.Range(population * 0.1f, population * 0.5f);

            if (seasonIndex == 0)
            {
                BuildingsManager.bInstance.foodProduction = BuildingsManager.bInstance.foodProductionStart;
            }
            else if (seasonIndex == 1)
            {
                BuildingsManager.bInstance.foodProduction = BuildingsManager.bInstance.foodProduction - 2;
            }
            else if (seasonIndex == 2)
            {
                BuildingsManager.bInstance.foodProduction = BuildingsManager.bInstance.foodProduction + 3;
            }
            else if (seasonIndex == 3)
            {
                BuildingsManager.bInstance.foodProduction = BuildingsManager.bInstance.foodProduction - 4;
            }
        }
    }

    IEnumerator EventTimer()
    {
        yield return new WaitForSeconds(eventTime);
        onEventDay.Invoke();

    }

    public void PopulationSpending()//metoda koja racuna potrošnju resura
    {
        food -= (int)(population/2);
        water -=(int)(population/2);


        gold -=soldier;
        gold -= (int)(worker * 0.5f);
    }


    public void CreatePawn()
    {
        if (citizen > 0)
        {
            citizen += (int)(house*0.3f);
            citizenText.text = "Citizen: " + population.ToString();
        }

    }

    void CalculateHappines()//metoda koja racuna happines uzima vrijednost i weatherManager skripte
    {
        happines = ItemsManager.iInstance.numberOfItemsClothing - citizen;
        happines = Mathf.Clamp(happines, -2, 5);
        Debug.Log(happines);
    }

    private void OnDisable()//ako ugasimo ili obrisemo objekt, neka makne Listener-e
    {
        onDayOver.RemoveListener(PopulationSpending);
        onDayOver.RemoveListener(CreatePawn);
        onDayOver.RemoveListener(CalculateHappines);
        onDayOver.RemoveListener(CheckResources);
    }

    void CheckResources()
    {

        if (food <= 0)
        {
            food = 0;

            notifications.text += string.Format("Your citizen are starving, you have no <color=#FF0000>food</color>, build more farms\n");

            citizen -= (int)Random.Range(citizen * 0.1f, citizen * 0.5f);

            if (citizen <= 0)
            {
                citizen = 0;
            }
        }

        if (water <= 0)
        {
            water = 0;

            notifications.text += string.Format("You don't have any <color=#FF0000>water</color>, build more wells\n");

            citizen -= (int)Random.Range(citizen * 0.1f, citizen * 0.5f);
            if (citizen <= 0)
            {
                citizen = 0;
            }
        }

        if (gold <= 0)
        {
            gold = 0;

            notifications.text += string.Format("You don't have any <color=#FF0000>gold</color>, sell some building of get rid of some soldiers\n");

            if (soldier > 0)
            {
                soldier -= Random.Range(2, 10);
                if (soldier < 0)
                {
                    soldier = 0;
                }
            }

            if (worker > 0) 
            {
                worker -= Random.Range(2, 10);
                if (worker < 0)
                {
                    worker = 0;
                }
            }

        }

        if (stone < 0)
        {
            stone = 0;
        }

        if (wood < 0)
        {
            wood = 0;
        }
        

        //if (water < population * 0.5)
        //{
        //    notifications.text += string.Format("You have <color=#FF0000>{0:0} water</color>, that is not enough\n", water);
        //}

        //if (food< population * 0.5)
        //{
        //    notifications.text += string.Format("You are low on food, you have <color=#FF0000>{0:0} food</color> in storage\n", food);
        //}
    }

}
