using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Well : MonoBehaviour,IBuilding, IPointerEnterHandler, IPointerExitHandler
{
    //cijena, oduzima se od resursa u GameManager-u
    public int goldCost;
    public int woodCost;
    public int stoneCost;
    public int citizenCost;

    int waterProduction;

    //kolicina resursa proizvedenog na kraju dana
    //public int waterProduction;
    //[SerializeField] int numberOfBuildings;
    //[SerializeField] TextMeshProUGUI wellText;

    [SerializeField] BuildingsManager buildingsManager;

    [SerializeField] TextMeshProUGUI wellDesc;
    [SerializeField] GameObject descriptionPanel;

    void Start()
    {
        waterProduction=buildingsManager.waterProduction;
        DescriptionText();
    }

    public void Cost()//metoda koja oduzima resurse kada kupujemo
    {
        GameManager.instance.wood -= woodCost;
        GameManager.instance.stone -= stoneCost;
        GameManager.instance.gold -= goldCost;
        GameManager.instance.citizen -= citizenCost;

        GameManager.instance.worker += citizenCost;
       
    }

    //public void Production()//metoda koja racuna proizvodnju na kraju dana, sada je u BuildingsManager-u
    //{
    //    //GameManager.instance.water += (int)(waterProduction + 1 * GameManager.happines)*numberOfBuildings;
    //}

    public void BuyBuilding()//metoda koja se poziva u UI za kupnju
    {
        if(GameManager.instance.wood>=woodCost&& GameManager.instance.stone>=stoneCost&& GameManager.instance.gold >= goldCost && GameManager.instance.citizen > 2 && GameManager.instance.citizen > citizenCost)
        {
            Cost();
            buildingsManager.numberOfBuildingsWells++;
            buildingsManager.wellText.text = buildingsManager.numberOfBuildingsWells.ToString();
        }
    }

    public void RefundCost()
    {
        GameManager.instance.wood += (int)woodCost / 2;
        GameManager.instance.stone += (int)stoneCost / 2;
        GameManager.instance.gold += (int)goldCost / 2;
        GameManager.instance.citizen += citizenCost;

        GameManager.instance.worker -= citizenCost;
    }

    public void SellBuilding()
    {
        if (buildingsManager.numberOfBuildingsWells > 0)
        {
            RefundCost();
            buildingsManager.numberOfBuildingsWells--;
            buildingsManager.wellText.text = buildingsManager.numberOfBuildingsWells.ToString();
        }
    }

    void DescriptionText()
    {
        wellDesc.text = string.Format("This building costs {0:0} wood, {1:0} stones and {2:0} gold.\n Produces {3:0} water", woodCost, stoneCost, goldCost, waterProduction);
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
