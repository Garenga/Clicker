using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksTrain : MonoBehaviour
{
    public Slider trainPeople;

    private void Start()
    {
        trainPeople.maxValue = GameManager.instance.citizen;
    }

    private void Update()
    {
        trainPeople.maxValue = GameManager.instance.citizen;
    }


    public void Training()
    {
        if (ItemsManager.iInstance.numberOfItemsSwords >= trainPeople.value && GameManager.instance.citizen > trainPeople.value && GameManager.instance.citizen > 2)
        {
            GameManager.instance.citizen -= (int)trainPeople.value;
            GameManager.instance.soldier += (int)trainPeople.value;

            ItemsManager.iInstance.numberOfItemsSwords-= (int)trainPeople.value;
        }
    }

    public void TrainingClick()
    {
        if (trainPeople.value > 0)
        {
            Training();
        }

    }
}
