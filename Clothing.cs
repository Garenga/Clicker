using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clothing : MonoBehaviour
{
    public int goldCost;
    public int numberOfItems;
    [SerializeField] TextMeshProUGUI itemText;


    private void Start()
    {
        itemText.text = numberOfItems.ToString();
    }

    public void Cost()
    {
        GameManager.instance.gold -= goldCost;
    }

    public void BuyItem()
    {
        if (GameManager.instance.gold >= goldCost)
        {
            Cost();
            ItemsManager.iInstance.numberOfItemsClothing++;
        }
    }
}
