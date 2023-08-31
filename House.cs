using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class House : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public int goldCost;
    public int woodCost;
    public int stoneCost;

    public BuildingsManager buildingsManager;

    [SerializeField] TextMeshProUGUI houseDesc;
    [SerializeField] GameObject descriptionPanel;

    private void Start()
    {
 
        buildingsManager.houseText.text = buildingsManager.numberOfBuildingsHouse.ToString();
        DescriptionText();
    }
    public void Cost()
    {
        GameManager.instance.wood -= woodCost;
        GameManager.instance.stone -= stoneCost;
        GameManager.instance.gold -= goldCost;
    }

    void DescriptionText()
    {
        houseDesc.text = string.Format("This building costs {0:0} wood, {1:0} stones and {2:0}gold.", woodCost, stoneCost, goldCost);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.SetActive(false);
    }

    public void BuyBuilding()
    {
        if (GameManager.instance.wood >= woodCost && GameManager.instance.stone >= stoneCost && GameManager.instance.gold >= goldCost)
        {
            Cost();
            buildingsManager.numberOfBuildingsHouse++;
            GameManager.instance.house++;
            buildingsManager.houseText.text = buildingsManager.numberOfBuildingsHouse.ToString();
        }
    }

}
