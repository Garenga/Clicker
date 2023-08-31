using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Quary : MonoBehaviour,IBuilding, IPointerEnterHandler, IPointerExitHandler
{
    public int goldCost;
    public int woodCost;
    public int stoneCost;
    public int citizenCost;

    int stoneProduction;

    [SerializeField] BuildingsManager buildingsManager;

    [SerializeField] TextMeshProUGUI quarryDesc;
    [SerializeField] GameObject descriptionPanel;

    void Start()
    {
        stoneProduction = buildingsManager.stoneProduction;
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


    public void BuyBuilding()
    {
        if (GameManager.instance.wood >= woodCost && GameManager.instance.stone >= stoneCost && GameManager.instance.gold >= goldCost && GameManager.instance.citizen > 2 && GameManager.instance.citizen > citizenCost)
        {
            Cost();
            buildingsManager.numberOfBuildingsQuarry++;
            buildingsManager.quaryText.text = buildingsManager.numberOfBuildingsQuarry.ToString();
        }
    }

    public void SellBuilding()
    {
        if (buildingsManager.numberOfBuildingsQuarry > 0) 
        {
            RefundCost();
            buildingsManager.numberOfBuildingsQuarry--;
            buildingsManager.quaryText.text = buildingsManager.numberOfBuildingsQuarry.ToString();

        }
    }

    void DescriptionText()
    {
        quarryDesc.text = string.Format("This building costs {0:0} wood, {1:0} stones and {2:0} gold.\n Produces {3:0} stone", woodCost, stoneCost, goldCost, stoneProduction);
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
