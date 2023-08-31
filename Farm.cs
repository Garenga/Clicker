using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Farm : MonoBehaviour, IBuilding, IPointerEnterHandler, IPointerExitHandler
{
    public int goldCost;
    public int woodCost;
    public int stoneCost;
    public int citizenCost;

    int foodProduction;

    [SerializeField] BuildingsManager buildingsManager;

    [SerializeField] TextMeshProUGUI farmDesc;
    [SerializeField] GameObject descriptionPanel;

    void Start() 
    {
        foodProduction=buildingsManager.foodProduction;
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
        GameManager.instance.wood += (int)woodCost/2;
        GameManager.instance.stone += (int)stoneCost /2;
        GameManager.instance.gold += (int)goldCost /2;
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
            buildingsManager.numberOfBuildingsFarms++;
            buildingsManager.farmsText.text = buildingsManager.numberOfBuildingsFarms.ToString();
        }
    }

    public void SellBuilding()
    {
        if (buildingsManager.numberOfBuildingsFarms>0)
        {
            RefundCost();
            buildingsManager.numberOfBuildingsFarms--;
            buildingsManager.farmsText.text = buildingsManager.numberOfBuildingsFarms.ToString();

        }
    }

    void DescriptionText()
    {
        farmDesc.text = string.Format("This building costs {0:0} wood, {1:0} stones and {2:0} gold.\n Produces {3:0} food", woodCost, stoneCost, goldCost, foodProduction);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.SetActive(false);
    }

//    private void OnDisable()
//    {
//        GameManager.instance.onDayOver.RemoveListener(Production);
//    }
}
