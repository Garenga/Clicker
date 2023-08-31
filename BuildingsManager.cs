using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public static BuildingsManager bInstance;

    [Header("Stone Production")]
    public int stoneProduction;
    public int stoneProductionStart;
    public int numberOfBuildingsQuarry;
    public TextMeshProUGUI quaryText;

    [Header("Food Production")]
    public int foodProduction;
    public int foodProductionStart;
    public int numberOfBuildingsFarms;
    public TextMeshProUGUI farmsText;

    [Header("Wood Production")]
    public int woodProduction;
    public int woodProductionStart;
    public int numberOfBuildingsLumbermill;
    public TextMeshProUGUI lumbermillText;

    [Header("Water Production")]
    public int waterProduction;
    public int waterProductionStart;
    public int numberOfBuildingsWells;
    public TextMeshProUGUI wellText;

    [Header("House")]
    public int numberOfBuildingsHouse;
    public TextMeshProUGUI houseText;


    private void Awake()
    {
        bInstance = this;
    }

    void Start()
    {
        GameManager.instance.onDayOver.AddListener(Production);

        numberOfBuildingsHouse = GameManager.instance.citizen;

        foodProductionStart = foodProduction;

        houseText.text = numberOfBuildingsHouse.ToString();
        lumbermillText.text = numberOfBuildingsLumbermill.ToString();
        wellText.text = numberOfBuildingsWells.ToString();
        farmsText.text = numberOfBuildingsFarms.ToString();
        quaryText.text = numberOfBuildingsQuarry.ToString();
    }

    private void Update()
    {

    }

    public void Production()
    {
        GameManager.instance.food += (int)(foodProduction + 1 * GameManager.instance.happines) * numberOfBuildingsFarms;
        GameManager.instance.water += (int)(waterProduction + 1 * GameManager.instance.happines) * numberOfBuildingsWells;
        GameManager.instance.stone += (int)(stoneProduction + 1 * GameManager.instance.happines) * numberOfBuildingsQuarry;
        GameManager.instance.wood += (int)(woodProduction + 1 * GameManager.instance.happines) * numberOfBuildingsLumbermill;
    }



}
