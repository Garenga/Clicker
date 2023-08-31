using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager iInstance;

    [SerializeField] TextMeshProUGUI swordsText;
    [SerializeField] TextMeshProUGUI clothingText;

    public Sword swordCount;
    public Clothing clothingCount;

    public int numberOfItemsSwords;
    public int numberOfItemsClothing;

    private void Awake()
    {
        iInstance = this;
    }

    private void Start()
    {

        swordsText.text = numberOfItemsSwords.ToString();
        clothingText.text = numberOfItemsClothing.ToString();
    }

    private void Update()
    {
        swordsText.text = numberOfItemsSwords.ToString();
        clothingText.text = numberOfItemsClothing.ToString();

        if (numberOfItemsClothing < 0)
        {
            numberOfItemsClothing = 0;
            GameManager.instance.happines = -1;
        }
    }
}
