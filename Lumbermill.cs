using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lumbermill : MonoBehaviour, IBuilding, IPointerEnterHandler, IPointerExitHandler
{
    public int goldCost;
    public int woodCost;
    public int stoneCost;
    public int citizenCost;

    int woodProduction;

    //public int woodProduction;
    //[SerializeField] int numberOfBuildings;
    //[SerializeField] TextMeshProUGUI lumbermillText;

    [SerializeField] BuildingsManager buildingsManager;

    [SerializeField] TextMeshProUGUI lumbermillDesc;
    [SerializeField] GameObject descriptionPanel;


    void Start()
    {
        woodProduction = buildingsManager.woodProduction;
        DescriptionText();
    }

    public void Cost()
    {
        GameManager.instance.wood -= woodCost;
        GameManager.instance.stone -= stoneCost;
        GameManager.instance.gold -= goldCost;
        GameManager.instance.citizen -= citizenCost;

        GameManager.instance.worker += citizenCost;
    }

    public void RefundCost()
    {
        GameManager.instance.wood += (int)woodCost / 2;
        GameManager.instance.stone += (int)stoneCost / 2;
        GameManager.instance.gold += (int)goldCost / 2;
        GameManager.instance.citizen += citizenCost;

        GameManager.instance.worker -= citizenCost;
    }

    public void Production()
    {

    }

    public void BuyBuilding()
    {
        if (GameManager.instance.wood >= woodCost && GameManager.instance.stone >= stoneCost && GameManager.instance.gold >= goldCost && GameManager.instance.citizen > 2 && GameManager.instance.citizen > citizenCost)
        {
            Cost();
            buildingsManager.numberOfBuildingsLumbermill++;
            buildingsManager.lumbermillText.text = buildingsManager.numberOfBuildingsLumbermill.ToString();
        }
    }

    public void SellBuilding()
    {
        if (buildingsManager.numberOfBuildingsLumbermill > 0)
        {
            RefundCost();
            buildingsManager.numberOfBuildingsLumbermill--;
            buildingsManager.lumbermillText.text = buildingsManager.numberOfBuildingsLumbermill.ToString();

        }
    }


    void DescriptionText()
    {
        lumbermillDesc.text = string.Format("This building costs {0:0} wood, {1:0} stones and {2:0} gold.\n Produces {3:0} wood", woodCost, stoneCost, goldCost, woodProduction);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.SetActive(false);
    }

}
